using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.Test
{
    [TestClass]
    public partial class Automaton
    {
        /// <summary>
        /// Is it valid to break if a rejection is noticed. What should happen?
        /// </summary>
        [TestMethod]
        public void OnlyAcceptsSingle1()
        {
            WooCompiler.FiniteAutomata.OnlyAcceptsSingle1 a = new FiniteAutomata.OnlyAcceptsSingle1();
            foreach (var c in "1")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new FiniteAutomata.OnlyAcceptsSingle1();
            foreach (var c in "11")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Rejected);
            Assert.IsFalse(a.Accepted);

            a = new FiniteAutomata.OnlyAcceptsSingle1();
            foreach (var c in "0")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Rejected);
            Assert.IsFalse(a.Accepted);

            a = new FiniteAutomata.OnlyAcceptsSingle1();
            foreach (var c in "01")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Rejected);
            Assert.IsFalse(a.Accepted);

            a = new FiniteAutomata.OnlyAcceptsSingle1();
            foreach (var c in "111111")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Rejected);
            Assert.IsFalse(a.Accepted);



        }

    }
}
