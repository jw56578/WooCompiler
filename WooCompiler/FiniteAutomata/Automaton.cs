using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata
{
    public class Automaton
    {
        //i can't initialize this to true if the loops are going to care if it rejected and then break loop
        //having both properties is necessary because as processing is being done, it is neither accepted or rejected

        public bool Rejected = false;
        public bool Accepted = false;
        protected State currentState;
        public Automaton()
        { 
        
        
        }
        public void Read(char input) {
            if (currentState != null)
            {
                currentState = currentState.Transition(input);
            }
        }
    }

    public class OnlyAcceptsSingle1:Automaton
    {

        public OnlyAcceptsSingle1()
        {
            
            //must always have an accepted state
            //1 means that this state can be transitioned to if its a 1
            var acceptedState = new State(null, "1", true,this);



            //must always have a start state
            //null means that this state cannot be transitioned to
            var startState = new State(new State[]{
                            acceptedState
                        }, null, false,this);

           
            //is there a better way to set the starting state, probably not, what else would you do
            this.currentState = startState;
        }
    }
    public class State
    {
        string pattern;
        List<State> states;
        public readonly bool isAcceptedState;
        Automaton automaton;
        public State(string regexPattern, Automaton automaton):this(null,regexPattern,false,automaton)
        {
         
        }
        public State(string regexPattern, bool isAcceptedState, Automaton automaton):this(null,regexPattern,isAcceptedState,automaton)
        {
        }
        public State(State[] states, string regexPattern, bool isAcceptedState, Automaton automaton)
        {
            this.automaton = automaton;
            this.states = states == null? null:  new List<State>(states);
            this.pattern = regexPattern;
            this.isAcceptedState = isAcceptedState;
        }
        public void AddState(State state)
        {
            this.states.Add(state);
        }
        public State Transition(char input)
        {
            //this is confusing things
            //there is a difference between transitioning to another thing and being able to transition to yourself
            //if you can transition to yourself then you need a reference to yourself in the state array
            //DO NOT TRANSITION TO YOURSELF BECAUSE YOU ARE SUPPOSE TO CHECK IF THERE IS A STATE YOU CAN MOVE TO


            //if states is null then that means this state cannot transition to anything even though something is trying to 
            //set rejected to true because you are trying to go forward on a state that can't go forward
            if (states == null) 
            {
                automaton.Rejected = true;
                automaton.Accepted = false;
                return this;
            }
            foreach (var s in states) {
                if (s.CanTransition(input)) {
                    if (s.isAcceptedState) 
                    {
                        automaton.Accepted = true;
                        automaton.Rejected = false;
                    }
                    return s;
                }
            }
            //we can't go anywhere - reject
            //but the machine could still be sending in input and if it meets another character that is good it will accept
            //at this point we need to say, stop: reject somehow
            automaton.Accepted = false;
            automaton.Rejected = true;
            return this;
        }
        public bool CanTransition(char input)
        {
            if (this.pattern == null)
                return false;
            var canTransition =  new Regex(this.pattern).Match(input.ToString()).Success;

            return canTransition;
        }
    
    }

    //how do you define states dynamically - just give it a RegEx to evaluation if its acceptable
    //then how do you define what things the state can go to  - give it a collection of other states and test whether the state can accept?
    //will the state itself just be in the collection of states?
    //
}
