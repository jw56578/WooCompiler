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
    /// </summary>
    public static class RegExDefinitions
    {
        //this will find a match for any single digit anywhere in a string
        //i have no idea what C# regex is doing, all it does is say its succesful
        // i can't understnad from the lecture, i assume we are suppose to test for only digits to exist???? figure out when sober
        public static string AnySingleDigit = "0|1|2|3|4|5|6|7|8|9";
        public static string ZeroOrMoreDigits = AnySingleDigit + "*";
        public static string NonEmptyStringOfDigits = AnySingleDigit + ZeroOrMoreDigits;
        //public static string AnySingleDigit = "[0-9]";
    }
}
