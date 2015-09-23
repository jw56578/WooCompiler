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
    public class RegExDefinitions
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

            it(regex.Match("0").Success);
            it(regex.Match("1").Success);
            it(regex.Match("2").Success);
            it(regex.Match("3").Success);
            it(regex.Match("4").Success);
            it(regex.Match("5").Success);
            it(regex.Match("6").Success);
            it(regex.Match("7").Success);
            it(regex.Match("8").Success);
            it(regex.Match("9").Success);

            it(regex.Match("11").Success);
            it(!regex.Match("A").Success);
            it(!regex.Match("b").Success);
            it(!regex.Match("393y2").Success);
            it(regex.Match("00").Success);
            it(!regex.Match("slkdfji2").Success);
            it(!regex.Match("l").Success);
            it(!regex.Match("o").Success);
            it(!regex.Match("abc").Success);
            it(!regex.Match("jenkins").Success);


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

            it(regex.Match("0").Success);
            it(regex.Match("1").Success);
            it(regex.Match("2").Success);
            it(regex.Match("3").Success);
            it(regex.Match("4").Success);
            it(regex.Match("5").Success);
            it(regex.Match("6").Success);
            it(regex.Match("7").Success);
            it(regex.Match("8").Success);
            it(regex.Match("9").Success);

            it(regex.Match("11").Success);
            it(!regex.Match("A").Success);
            it(!regex.Match("b").Success);
            it(!regex.Match("393y2").Success);
            it(regex.Match("00").Success);
            it(!regex.Match("slkdfji2").Success);
            it(!regex.Match("l").Success);
            it(!regex.Match("o").Success);
            it(!regex.Match("abc").Success);
            it(!regex.Match("jenkins").Success);


        }

        [TestMethod]
        public void IsAnySingleDigit()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.AnySingleDigit);

            //what is the value of this compared to IsNonEmptyStringOfDigits
            //as noted above, do not care about group, this is irrelevant to parsing things
            var match = regex.Match("sdlkfj5555566666sljlxk");
           // Assert.AreEqual(match.Groups[0].Value, "5555566666");




            it(regex.Match("0").Success);


            it(regex.Match("0").Success);
            it(regex.Match("1").Success);
            it(regex.Match("2").Success);
            it(regex.Match("3").Success);
            it(regex.Match("4").Success);
            it(regex.Match("5").Success);
            it(regex.Match("6").Success);
            it(regex.Match("7").Success);
            it(regex.Match("8").Success);
            it(regex.Match("9").Success);

            it(regex.Match("11").Success);
            it(!regex.Match("A").Success);
            it(!regex.Match("b").Success);
            it(!regex.Match("393y2").Success);
            it(regex.Match("00").Success);
            it(!regex.Match("slkdfji2").Success);
            it(!regex.Match("l").Success);
            it(!regex.Match("o").Success);
            it(!regex.Match("abc").Success);
            it(!regex.Match("jenkins").Success);


        }
        public void it(bool input)
        {
            Assert.IsTrue(input);
        }
    }
}
