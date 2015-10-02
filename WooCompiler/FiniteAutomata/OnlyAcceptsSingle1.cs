using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata
{
    public class OnlyAcceptsSingle1 : Automaton
    {

        public OnlyAcceptsSingle1()
        {

            //must always have an accepted state
            //1 means that this state can be transitioned to if its a 1
            var acceptedState = new State(null, "1", true, this);



            //must always have a start state
            //null means that this state cannot be transitioned to
            var startState = new State(new State[]{
                            acceptedState
                        }, null, false, this);


            //is there a better way to set the starting state, probably not, what else would you do
            this.startState = this.currentState = startState;
        }
    }
}
