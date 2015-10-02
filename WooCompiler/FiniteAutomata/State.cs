using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata
{
    public class State
    {
        string pattern;
        List<State> states;
        public readonly bool isAcceptedState;
        Automaton automaton;
        public bool IsAccepted = false;
        public State(string regexPattern, Automaton automaton)
            : this(null, regexPattern, false, automaton)
        {

        }
        public State(string regexPattern, bool isAcceptedState, Automaton automaton)
            : this(null, regexPattern, isAcceptedState, automaton)
        {
        }
        public State(State[] states, string regexPattern, bool isAcceptedState, Automaton automaton)
        {
            this.automaton = automaton;
            this.states = states == null ? null : new List<State>(states);
            this.pattern = regexPattern;
            this.isAcceptedState = isAcceptedState;
        }
        public void AddState(State state)
        {
            this.states.Add(state);
        }
        public State Transition(char input)
        {
            //DO NOT TRANSITION TO YOURSELF BECAUSE YOU ARE SUPPOSE TO CHECK IF THERE IS A STATE YOU CAN MOVE TO


            //if states is null then that means this state cannot transition to anything even though something is trying to 
            //set rejected to true because you are trying to go forward on a state that can't go forward
            if (states == null)
            {
                this.IsAccepted = false;
                automaton.Rejected = true;
                return this;
            }
            foreach (var s in states)
            {
                if (s.CanTransition(input))
                {
                    if (s.isAcceptedState)
                    {
                        s.IsAccepted = true;
                        automaton.Rejected = false;
                    }
                    return s;
                }
            }
            //we can't go anywhere - reject
            //but the machine could still be sending in input and if it meets another character that is good it will accept
            //at this point we need to say, stop: reject somehow
            this.IsAccepted = false;
            automaton.Rejected = true;
            return this;
        }
        public bool CanTransition(char input)
        {
            if (this.pattern == null)
                return false;
            var canTransition = new Regex(this.pattern).Match(input.ToString()).Success;

            return canTransition;
        }

    }

    //how do you define states dynamically - just give it a RegEx to evaluation if its acceptable
    //then how do you define what things the state can go to  - give it a collection of other states and test whether the state can accept?
    //will the state itself just be in the collection of states?
    //
}
