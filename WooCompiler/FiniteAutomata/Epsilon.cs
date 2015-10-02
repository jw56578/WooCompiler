using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata
{
    public class Epsilon : Automaton
    {
        public Epsilon()
        {

            //must always have an accepted state
            //0 means that this state can be transitioned to if its a 0
            var acceptedState = new State(null, "", true, this);



            //must always have a start state
            //this state can transition to itself, is there a better way to code this
            State startState = null;
            startState = new State(new State[]{
                            acceptedState
                        },null, false, this);
         


            //is there a better way to set the starting state, probably not, what else would you do
           startState =  this.currentState = startState;
            
        }
        //shortcutting this by not using state
        public override void Read(string input)
        {
            if (string.IsNullOrEmpty(input)) {
                this.Accepted = true;
                this.Rejected = false;
            }
            
        }

    }
}
