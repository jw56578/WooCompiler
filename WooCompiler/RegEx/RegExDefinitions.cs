using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler
{
    /// <summary>
    /// I still don't know what the point of this is
    /// are we suppose to be regexing one character at a time? or what. haven't gotten to that point yet
    /// the video lecture uses parenthesis but in c# this is already a thing so i'm not sure what needs to be done
    /// </summary>
    public static partial class RegExDefinitions
    {
        //this will find a match for any single digit anywhere in a string
        //this will only "FIND" the first match, i think there is a c# thing to find all matches, but i don't know what this matters
        //so for "xx34545lksdjf" it will match but it will only capture the first "3" and there is no way to get the other numbers
        public static string AnySingleDigit = "0|1|2|3|4|5|6|7|8|9";

        //what does this do?
        //this is totally confusing, the regex match is successfull, but the capture has nothing in it
        public static string MultipleSingleDigits = "0|1|2|3|4|5|6|7|8|9*";

        //what does this do?
        //again this does nothing, the match is successful, but nothign is captured
        public static string AllMultipleSingleDigits = "(0|1|2|3|4|5|6|7|8|9)*";


        //this doesn't even affect anything, the parenthesis still make there only be 1 match group for the first digit found
        public static string AllSingleDigits = ("0|1|2|3|4|5|6|7|8|9");



        public static string ZeroOrMoreDigits = AnySingleDigit + "*";
        public static string NonEmptyStringOfDigits = AnySingleDigit + ZeroOrMoreDigits;
        //public static string AnySingleDigit = "[0-9]";
    }
}
