using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata
{
    public class AcceptsAnyNumberof1sFollowedBySingleZero : Automaton
    {
        public AcceptsAnyNumberof1sFollowedBySingleZero()
        {

            //must always have an accepted state
            //0 means that this state can be transitioned to if its a 0
            var acceptedState = new State(null, "0", true, this);



            //must always have a start state
            //this state can transition to itself, is there a better way to code this
            State startState = null;
            startState = new State(new State[]{
                            acceptedState
                        }, "1", false, this);
            startState.AddState(startState);


            //is there a better way to set the starting state, probably not, what else would you do
            this.currentState = startState;
        }
    }
}
