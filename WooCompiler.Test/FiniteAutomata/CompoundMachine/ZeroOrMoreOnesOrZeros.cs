using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WooCompiler.FiniteAutomata.CompoundMachines;

namespace WooCompiler.Test
{
 
    public partial class CompoundMachine
    {
        [TestMethod]
        public void ZeroOrMoreOnesOrZerosFollowedByOne()
        {
            var a = new ZeroOrMoreOnesOrZerosFollowedByOne();
            Assert.IsFalse(a.Accepted);
            Assert.IsFalse(a.Rejected);
            foreach(var s in new string[]{"01","11111","01001001"})
            {
                a = new ZeroOrMoreOnesOrZerosFollowedByOne();
                Functions.TestRead(a, s, true, false);
            }
            //what is going on here, Rejected can't be set to true unless it somehow knows its at the end olf the input
            //how do atomatons know this, reject will never be true
            foreach (var s in new string[] { "0","1010101010" })
            {
                a = new ZeroOrMoreOnesOrZerosFollowedByOne();
                Functions.TestRead(a, s, false, true);
            }

        }
        [TestMethod]
        public void ZeroOrMoreOnesOrZeros()
        {
            var a = new ZeroOrMoreOnesOrZeros();
            foreach (var s in "1")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new ZeroOrMoreOnesOrZeros();
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new ZeroOrMoreOnesOrZeros();
            foreach (var s in "0")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new ZeroOrMoreOnesOrZeros();
            foreach (var s in "111111")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);


            a = new ZeroOrMoreOnesOrZeros();
            foreach (var s in "0000000")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new ZeroOrMoreOnesOrZeros();
            foreach (var s in "11101010010")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);


            a = new ZeroOrMoreOnesOrZeros();
            foreach (var s in "1017010")
            {
                a.Read(s);
            }
            Assert.IsFalse(a.Accepted);
            Assert.IsTrue(a.Rejected);

        }
    }
}
