using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Test
{
    [TestClass]
    public class RecursiveDecentCalculatorParser
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

        //where the hell do you put the code to actually do any work???

        int currentPosition = -1;
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
         
            Assert.IsTrue(!E() || currentPosition< tokens.Length);
        }
        //  E -> E + T | E - T | T
        //      T -> T * P | T / P | P
        //      P -> ( T ) | n

        public bool E()
        { 
            var result = E1();
            if(result)
            {
                return result;
            }
            Reset();
            result = E2();
            if (result)
            {
                return result;
            }
            Reset();
            result = E3();
            if (!result)
                Reset();
            return result;
        }
        public bool E1()
        {
            return T() && Term( "+") && E();
        }
        public bool E2()
        {
            return T() && Term("-") && E();
        }
        public bool E3()
        {
            return T();
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
            if (!result)
                Reset();
            return result;
        
        }
        //      T -> T * P | T / P | P
        bool T1()
        {
            return  P() && Term("*") && T();
        }
        bool T2()
        {
            return P() && Term( "/") && T();
        }
        bool T3()
        {
            return P();
        }
        // P -> ( T ) | n
        public bool P()
        {
            var result = P1();
            if (result)
            {
                return result;
            }
            Reset();
            result = P2();
            if (!result)
                Reset();
            return result;
        }
        public bool P1()
        {
            return Term( "(") && T() && Term( ")");
        }
        public bool P2()
        {
            return Term( "int");
        }
        bool Term(string symbol) 
        {
            currentPosition++;
            if(currentPosition < tokens.Length)
                currentToken = tokens[currentPosition];
            return this.currentToken.Symbol == symbol;
        }
        void Reset()
        {
            currentPosition--;
            if (currentPosition == tokens.Length - 1)
                currentPosition--;
            if (currentPosition < 0)
                currentPosition = 0;
            if(currentPosition < tokens.Length)
                currentToken = tokens[currentPosition];
        }
        private class Token
        {
            public string Symbol;
            public string Value;
        }
    }
}
