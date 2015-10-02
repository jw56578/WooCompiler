using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Test
{
    [TestClass]
    public class PredictiveParser
    {
        /*
         * this is the original production rules that won't work in a predictive parser
            E->T +E |T
            T->int | int * T |(E)
            
         * 
            this is the left factored rules that should work in a predictive parser
            E-> TX
            X-> +E |e
            T->intY | (E)
            Y ->*T|e
         * The code here should be simpler but the trick is how do you reprsent a parsing table in code DataTable?
         * 
         * 
       */
        Dictionary<string, Dictionary<string, string>> parsingTable = new Dictionary<string, Dictionary<string, string>>();
        Stack<string> parseStack = new Stack<string>();
        int currentPosition = 0;
        Token[] tokens = null;
        Token currentToken = null;

        public PredictiveParser()
        {
            
            //how to you represent TX which needs to be able to be seperated into T and X
            //just split on characters??no because there is int which is 3 characters
            //can't delimit them because any character  could be a valid terminal. shit
            //should we pick a character that is not allowed to be used in the language
            parsingTable.Add("int", new Dictionary<string, string>() {
                {"E","T X"},
                {"X",""},
                {"T","int Y"},
                {"Y",""}
            });
            parsingTable.Add("*", new Dictionary<string, string>() {
                {"E",""},
                {"X",""},
                {"T",""},
                {"Y","* T"}
            });
            parsingTable.Add("+", new Dictionary<string, string>() {
                {"E",""},
                {"X","+ E"},
                {"T",""},
                {"Y","e"}
            });
            parsingTable.Add("(", new Dictionary<string, string>() {
                {"E","T X"},
                {"X",""},
                {"T","( E )"},
                {"Y",""}
            });
            parsingTable.Add(")", new Dictionary<string, string>() {
                {"E",""},
                {"X","e"},
                {"T",""},
                {"Y","e"}
            });
            parsingTable.Add("", new Dictionary<string, string>() {
                {"E",""},
                {"X","e"},
                {"T",""},
                {"Y","e"}
            });
        }
        [TestMethod]
        public void CanPredictiveParseIntPlusIntTimesInt()
        {
            //why doesn't the parsing table work for this
            //somehow the terminal is X when it sees the * which is a nothing so then it just stops
            //dammit nothing ever works!!!!
            tokens = new Token[]{
                new Token(){Symbol="("},
                new Token(){Symbol="int",Value = "1"},
                new Token(){Symbol="+"},
                new Token(){Symbol="int",Value = "2"},
                new Token(){Symbol=")"},
                new Token(){Symbol="*"},
                new Token(){Symbol="int",Value = "3"},
            };
            ParseNode parent = new ParseNode() { Symbol = "E" };
            Parse(parent);
            var result = parent.GetResult();
        }
        [TestMethod]
        public void CanPredictiveParseIntTimesInt()
        {

            tokens = new Token[]{
                new Token(){Symbol="int",Value = "2"},
                new Token(){Symbol="*"},
                new Token(){Symbol="int",Value = "3"},
            };
            ParseNode parent = new ParseNode() { Symbol = "E" };
            Parse(parent);
            var result = parent.GetResult();
        }
        void Parse(ParseNode parent)
        {
            parseStack.Push("E");
           
            ParseNode currentNode = parent;
            while (parseStack.Count() > 0) 
            {
                var current = parseStack.Pop();
                if (current == "")
                {
                    throw new Exception("Invalid code");
                }
                var token = GetCurrenToken();
                Dictionary<string, string> next = null;
                string next1 = null;

                if (token != null)
                {
                    next = parsingTable[token.Symbol];
                }
                else
                {
                    next = parsingTable[""];
                }

                if (token !=null && !next.ContainsKey(current) && current == token.Symbol)
                {
                    currentPosition++;
                }
                else
                {
                    //does not contain would be "e"
                    if (next.ContainsKey(current))
                    {
                        next1 = next[current];
                        //how do we parse the terminal combinations?? one space?
                        var terminals = next1.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                        //push to the stack from right to left
                        ParseNode lastNode = null;
                        for (int i = terminals.Length - 1; i >= 0; i--)
                        {
                            parseStack.Push(terminals[i]);
                            //we can't make the last node a terminal
                            var temp = new ParseNode() { Symbol = terminals[i] };
                            if (!parsingTable.ContainsKey(terminals[i]))
                                lastNode = temp;
                            else
                            {
                                temp.Value = token == null ? "" : token.Value;
                            }
                            currentNode.Nodes.Add(temp);
                        }
                        currentNode = lastNode;
                    }
                }
            }
        }
        public class ParseNode
        {
            public string Symbol;
            public List<ParseNode> Nodes = new List<ParseNode>();
            public string Value;
            public object GetResult() 
            {
                //how will this recursion work
                object result1 = null;
                object result2 = null;
                if (Nodes.Count() > 0)
                {
                    result1 = Nodes[0].GetResult();
                }
                if (Nodes.Count() > 1)
                {
                    result2 = Nodes[1].GetResult();
                }
                return NodeService.GetResult(this, result1, result2);
            
            }
        
        }
        public class NodeService
        {
            public static object GetResult(ParseNode node, object result1, object result2) {
                if (node.Symbol == "+")
                {
                    return (int)result1 + (int)result2;
                }
                return node.Value;
            }
        
        }
        Token GetCurrenToken()
        {
            if(currentPosition < tokens.Length)
                return tokens[currentPosition];
            return null;
        }
        private class Token
        {
            public string Symbol;
            public string Value;
        }
    }
}
