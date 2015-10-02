using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Test
{
    [TestClass]
    public class RecursiveDecentParser
    {
        /*
        E->T | T+E
        T->int|int * T |(E)
         * 
         * these are the production rules from the video lecture but these will not really work
         * because of how Recursive Decent works, if you had 1*1, the parser would quit after just seeing the first 1
         * you have to manually rewrite the production rules in order to make it work
         * so in order for things to full work you would need to change the above rules to
         * E-> T+E | T
         * T-> T*P | P
         * P-> (E) | int
        */
     //  E -> E + T | E - T | T
    //      T -> T * P | T / P | P
    //      P -> ( T ) | n


        int currentPosition = 0;
        Token[] tokens = null;
        Token currentToken = null;
        [TestMethod]
        public void TestIntegerInParensSuccesful()
        {
            tokens = new Token[]{
                new Token(){Symbol="("},
                new Token(){Symbol="int",Value = "5"},
                new Token(){Symbol=")"},
            
            };
            currentToken = tokens[0];
            Assert.IsTrue(E());
        }
        [TestMethod]
        public void IntegerPlusIntegerSuccesful()
        {
            tokens = new Token[]{
                new Token(){Symbol="int",Value = "5"},
                new Token(){Symbol="+"},
                new Token(){Symbol="int",Value = "5"},
            
            };
            currentToken = tokens[0];
            Assert.IsTrue(E() && currentPosition < tokens.Length);
        }
        [TestMethod]
        public void IntegerMinusIntegerUnSuccesful()
        {
            tokens = new Token[]{
                new Token(){Symbol="int",Value = "5"},
                new Token(){Symbol="-"},
                new Token(){Symbol="int",Value = "5"},
            
            };
            currentToken = tokens[0];
            Assert.IsTrue(!E() || currentPosition< tokens.Length);
        }
       
        public bool E()
        { 
            var result = E1();
            if(result)
            {
                return result;
            }
            Reset();
            result = E2();
            return result;
        }
        public bool E1()
        {
            return T();
        }
        public bool E2()
        {
            return T() && Term(currentToken,"+") && E();
        }
        public bool T()
        {
            var result = T1();
            if (result)
            {
                return result;
            }
            Reset();
            result = T2();
            if (result)
            {
                return result;
            }
            Reset();
            result = T3();
            return result;
        
        }
        bool T1()
        {
            return Term(currentToken,"int");
        }
        bool T2()
        {
            return Term(currentToken, "int") && Term(currentToken, "*") && T();
        }
        bool T3()
        {
            return Term(currentToken, "(") && E() && Term(currentToken, ")");
        }
        bool Term(Token t,string symbol) 
        {
            currentPosition++;
            if(currentPosition < tokens.Length)
                currentToken = tokens[currentPosition];
            return t.Symbol == symbol;
        }
        void Reset()
        {

            currentPosition--;
            currentToken = tokens[currentPosition];
        }
        private class Token
        {
            public string Symbol;
            public string Value;
        }
    }
}
