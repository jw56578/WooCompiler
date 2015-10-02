using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler.FiniteAutomata.CompoundMachines
{
    public class ZeroOrMoreOnesOrZerosFollowedByOne : ZeroOrMoreOnesOrZeros
    {
        SingleSpecificCharacter a = new SingleSpecificCharacter('1');
        public ZeroOrMoreOnesOrZerosFollowedByOne()
        { 
            //epsilon is no longer acceptable, so reset back to default state
            //that is all that is required for this thing. it doesn' allow epsilon because at least one 1 is required
            //need to test what would happen if one zero
            this.Reset();
        
        }
        public override void Read(char input)
        {
            base.Read(input);

            //this thing itself has no idea if the input is at the end, so how could it ever know what is at the end
            //everything might have to be redesigned to accept the entire string input

            //now we have something that is storing whether the last input was 1 but how the hell do we know if its the last character
            //wouldn't it just work itself out?
            //if 
            a = new SingleSpecificCharacter('1');
            a.Read(input);
            //wouldn't it just work itself out?
            //if at this point this thing itself is Accepted and a is accepted then the whole thing is okay
            //but if a is not accepted then you can set this thing itself to accepted = false because if another good input is given it will just reset itself back to accepted = true
            if (!a.Accepted)
            {
                this.Accepted = false;
            }
        }
    }
    public class ZeroOrMoreOnesOrZeros:Automaton
    {
        protected OneOrZero a = new OneOrZero();

        public ZeroOrMoreOnesOrZeros()
        {
            //the input to this could be that there is no input (Eplison )which means Read will never be called
            //in order to accmodate this, start off at rejected = false and accpeted = true because if nothing happens this mahcine will be in an acceptable state no matter what

            this.Rejected = false;
            this.Accepted = true;
        }
        public override void Read(char input)
        {
            //next issue is that this thing is dependent on a loop to exit when rejected
            //if you send in 11111161111 then it will work till the 6 but then reading in the next 1 will set it back to accepted
            //do i need to maintain a flag that if it is ever rejected then it can never be reset
            //this can be solved by simply returning out if rejected is true
            if (this.Rejected)
                return;

            //this represents the loop, the consumer can call Read as many times as necessary 
            //what needs to be handled here is reseting the OneOrZero Reject and Accepted in order to allow many 1s or 0s to be inputted
            //else after the second read the automaton will be rejected
            //there needs to be a way to do this for all children 
            a.Reset();
            a.Read(input);
            this.Accepted = a.Accepted;
            this.Rejected = a.Rejected;

             
            

        }
    }
}
