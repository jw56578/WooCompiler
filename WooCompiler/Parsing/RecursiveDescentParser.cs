using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Parsing
{
    //not sure how to organize this yet
    //need context free grammer definitions

    // you take in each character at a time
    //then you run your grammer rules starting from top to bottom
    //then you compare the input character to the leaf node of the parse tree 
    //if they are equal then do ?? else undo the tree and try another path

    //top start symbol is expression - an expression in code is anything = E
    //an expression can be a T or a T + E
    //T is a meaningless place holder which represents sub expressions
    // T could be an int or an int * T or (E) = 5 or 5 * 5 or (4)

    //how does code represent the definition of the language is the trick here

    //how do you represent that E can be T + E, just maintain the characters?
    //O every symbol has to be its own class duh
    // + and * have to be Types

    class RecursiveDescentParser
    {
        public RecursiveDescentParser()
        {
            Terminal expression = new Expression();
            Terminal T = new T();

            //how do we store multiple symbols?
            expression.Terminals = new Terminal[] { 
                T,
            };
            T.Terminals = new Terminal[] { 
                T,
            };
        
        }

        public void Parse()
        {

            foreach (var c in "(int4)")
            { 
            
            }
        }
        public void MakeParseTree()
        { 
        
        
        }
    }

    //there are 2 concepts here 1) how do I describe the production rules in code 2) the tree created when doing recursive decent
     //so far no terminal has had more than 3 branches, is this how it always is, try this first
        //public Terminal Left;
        //public Terminal Center;
        //public Terminal Right;



    public abstract class Terminal
    {
       

        public Terminal[] Terminals;
        public string Name;
        public string Symbol;
        public bool IsNon = false;
        public Terminal(bool isNonTerminal)
        {
            IsNon = isNonTerminal;
        }
    }
    //public class NonTerminal: Terminal
    //{ 
    
    //}
    public class Plus : Terminal
    {
        public Plus()
            : base(false)
        { 
        
        }
    }
    public class Multiply : Terminal
    {
        public Multiply()
            : base(false)
        {

        }
    }
    public class T : Terminal
    {
        public T():base(true)
        { 
        
        }
    }
    public class Expression : Terminal
    {
        public Expression()
            : base(true)
        { 
        
        }
    
    }
}
