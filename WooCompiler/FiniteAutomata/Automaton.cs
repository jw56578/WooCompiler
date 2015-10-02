using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata
{
    public abstract class Automaton
    {
        //i can't initialize this to true if the loops are going to care if it rejected and then break loop
        //having both properties is necessary because as processing is being done, it is neither accepted or rejected
        //BUT there is never any need to know if you are in a mid state, either you are accepted or not
        public bool Rejected = false;
        public bool Accepted = false;
        protected State startState;
        protected State currentState;
        Automaton goToOnAccepted;
        public Automaton( )
        { 
        
        
        }
        //you have to be able to take 2 or more existing machines and join them together
        //if you get to the final state of one machine then it needs to be able to link to the start state of another machine
        public Automaton(Automaton goToOnAccepted )
        {
            this.goToOnAccepted = goToOnAccepted;
        }
        public virtual void Reset() {
            this.Rejected = false;
            this.Accepted = false;
            this.currentState = startState;
        }
        /// <summary>
        /// should this exist? will the automaton be responsble for looping the input string. Perhaps just create this ability
        /// </summary>
        /// <param name="input"></param>
        public virtual void Read(string input)
        {
            foreach (var c in input) {
                this.Read(c);
            }
        }
        public virtual void Read(char input) {
            if (startState == null)
                throw new Exception("type: " + this.GetType() + " did not set its start state field. Need to figure out a better way to do this");
            if (currentState != null)
            {
                currentState = currentState.Transition(input);
                if (currentState.isAcceptedState && currentState.IsAccepted)
                {
                    this.Accepted = true;
                    //if we are accepted but there is another connected automaoton we must jump to its starting state
                    //how is this going to work 
                    if (this.goToOnAccepted != null)
                    {
                        currentState = this.goToOnAccepted.currentState;
                    }
                }
                else {

                    this.Accepted = false;
                }
            }
        }
    }

  
   
}
