using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata.CompoundMachines
{
    /// <summary>
    /// I am interpreting from the lecture that a compound machine can also have states
    /// and you can transition from a state to the input of another automaton
    /// </summary>
    public class CompoundMachine
    {
        Automaton a;
        Automaton b;
        public CompoundMachine()
        {
            b = new SingleCharacter();
            a = new SingleCharacter(b);

        }
        public void Read(char input) {

            a.Read(input);
        }
    }
    /// <summary>
    /// so what the hell makes this thing take an input and then just go to one automaton or the other
    /// i guess you just randomly choose one and if it gets accepted then you just go with that one, else try the other one??
    /// when you have an epsilon transition i guess that just means that you go to one state and don't change the input value
    /// 
    /// </summary>
    public class OneOrZero:Automaton
    { 
        Automaton a;
        Automaton b;
        public OneOrZero()
        {
            b = new SingleSpecificCharacter('1');
            a = new SingleSpecificCharacter('0');

        }
        /// <summary>
        /// I think the lecture diagrams are just for visual representation
        /// there is no state that moves from start to epsilon,in code you just move to one state and then if its okay stay there
        /// else move to the other states
        /// </summary>
        /// <param name="input"></param>
        public void Read(char input) {

            b.Read(input);
            if (b.Accepted)
            {

                IsAccepted();
            }
            else 
            {
                a.Read(input);
                if (a.Accepted)
                {
                    IsAccepted();
                }
                else {
                    Accepted = false;
                    Rejected = true;
                }
            }
        }
        /// <summary>
        /// now what? The lecture diagram just shows moving to a end state, but its not an accept state, it just passes off to the next state
        /// </summary>
        void IsAccepted() {
            Accepted = true;
            Rejected = false;
        }
        public override void Reset()
        {
            a.Reset();
            b.Reset();
            base.Reset();
        }
    }
}
