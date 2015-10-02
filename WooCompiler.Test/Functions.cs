using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Test
{
    public static class Functions
    {
        public static void TestRead(WooCompiler.FiniteAutomata.Automaton a, string input, bool accept, bool reject)
        {
            foreach (var s in input)
            {
                a.Read(s);
            }
            Assert.AreEqual(a.Accepted,accept);
            Assert.AreEqual(a.Rejected,reject);
           
        
        }
    }
}
