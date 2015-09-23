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
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AcceptsAnyNumberof1sFollowedBySingleZero()
        {
            var a = new FiniteAutomata.AcceptsAnyNumberof1sFollowedBySingleZero();
            foreach (var c in "10")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new FiniteAutomata.AcceptsAnyNumberof1sFollowedBySingleZero();
            foreach (var c in "11111111110")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsTrue(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new FiniteAutomata.AcceptsAnyNumberof1sFollowedBySingleZero();
            foreach (var c in "1")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            //did i miss this in the lecture? if the machine is stuck on a state that isn't accepted then how does rejeted get set
            //not sure how to handle this yet
            //all consuming code will have to check Accept and Reject
            Assert.IsFalse(a.Accepted);
            Assert.IsFalse(a.Rejected);

            a = new FiniteAutomata.AcceptsAnyNumberof1sFollowedBySingleZero();
            foreach (var c in "100000")
            {
                a.Read(c);
                if (a.Rejected)
                    break;
            }
            Assert.IsFalse(a.Accepted);
            Assert.IsTrue(a.Rejected);
        }
    }
}
