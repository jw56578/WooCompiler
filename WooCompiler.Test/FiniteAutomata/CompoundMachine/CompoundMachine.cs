using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WooCompiler.FiniteAutomata.CompoundMachines;

namespace WooCompiler.Test
{
    [TestClass]
    public partial class CompoundMachine
    {
        [TestMethod]
        public void Concat()
        {
            var a = new WooCompiler.FiniteAutomata.CompoundMachines.CompoundMachine();
            foreach (var s in "ab")
            {
                a.Read(s);
            }

           
        }
        [TestMethod]
        public void OneOrZero()
        {
            var a = new OneOrZero();
            foreach (var s in "1")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new OneOrZero();
            foreach (var s in "0")
            {
                a.Read(s);
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new OneOrZero();
            foreach (var s in "3")
            {
                a.Read(s);
            }
            Assert.IsFalse(a.Accepted);
            Assert.IsTrue(a.Rejected);

            a = new OneOrZero();
            foreach (var s in "11")
            {
                a.Read(s);
            }
            Assert.IsFalse(a.Accepted);
            Assert.IsTrue(a.Rejected);
            a = new OneOrZero();
            foreach (var s in "00")
            {
                a.Read(s);
            }
            Assert.IsFalse(a.Accepted);
            Assert.IsTrue(a.Rejected);

            a = new OneOrZero();
            foreach (var s in "1010101")
            {
                a.Read(s);
            }
            Assert.IsFalse(a.Accepted);
            Assert.IsTrue(a.Rejected);


        }
    }
}
