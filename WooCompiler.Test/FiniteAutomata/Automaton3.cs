using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Test
{
    public partial class Automaton
    {
        [TestMethod]
        public void Epsilon()
        {
            var a = new FiniteAutomata.Epsilon();
            a.Read("");

            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);
        }
    
    }
}
