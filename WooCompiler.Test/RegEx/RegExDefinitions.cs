using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace WooCompiler.Test
{
    //this is fucked up, i have no idea how MS regex works so i can't use it to emulate the stuff
    //ah shit, in .net the parenthesis are used as capture gropus so i can't use that here

    //the groups have nothing to do with capturing matches
    //dont' pay attention to the group collection it is confusing
    //it requires each match to be surrounded in () to be in a group
    [TestClass]
    public partial class RegExDefinitions
    {
        //i'm not sure what this is suppose to do in relation to the Lexer
        //are you suppose to match if the string contains only 1 or more digits or match if there are alphabet characters mixed in
        [TestMethod]
        public void IsNonEmptyStringOfDigits()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.NonEmptyStringOfDigits);
            var match = regex.Match("sdlkfj5555566666sljlxk");
            //what is the value of this compared to IsAnySingleDigit
            // the difference is that the first group of match will contain the entire string of the number 555556666, where as the single digit will only contain the single digit 5
            Assert.AreEqual(match.Groups[0].Value, "5555566666");
            it(regex.Match("0").Success);

          

        }
        [TestMethod]
        public void IsZeroOrMoreDigits()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.ZeroOrMoreDigits);

            var match = regex.Match("sdlkfj5555566666sljlxk");
            //what is the value of this compared to IsAnySingleDigit
            // holy shit, this has no values in any of the groups yet match success is true
            Assert.AreEqual(match.Groups[0].Value, "5555566666");
            it(regex.Match("0").Success);




        }
        [TestMethod]
        public void AllMultipleSingleDigits()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.AllMultipleSingleDigits);

            //what is the value of this compared to IsNonEmptyStringOfDigits
            //as noted above, do not care about group, this is irrelevant to parsing things
            var match = regex.Match("sdlkfj5555566666sljlxk");
        }
        [TestMethod]
        public void MultipleSingleDigits()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.MultipleSingleDigits);

            //what is the value of this compared to IsNonEmptyStringOfDigits
            //as noted above, do not care about group, this is irrelevant to parsing things
            var match = regex.Match("sdlkfj5555566666sljlxk");
        }
        [TestMethod]
        public void AllSingleDigits()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.AllSingleDigits);

            //what is the value of this compared to IsNonEmptyStringOfDigits
            //as noted above, do not care about group, this is irrelevant to parsing things
            var match = regex.Match("sdlkfj5555566666sljlxk");
        }
        [TestMethod]
        public void IsAnySingleDigit()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.AnySingleDigit);
            it(!regex.Match("").Success);
            it(!regex.Match("x").Success);
            it(regex.Match("1").Success);

        }
        public void it(bool input)
        {
            Assert.IsTrue(input);
        }
    }
}
