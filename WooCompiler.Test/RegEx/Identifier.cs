using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace WooCompiler.Test
{
  
    public partial class RegExDefinitions
    {
        [TestMethod]
        public void AllLetters()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.AllLetters);
            var match = regex.Match("sdlkfj5555566666sljlxk");
            it(match.Success);
            it(!regex.Match("3").Success) ;
            it(!regex.Match("@").Success);
        }
        [TestMethod]
        public void Identifier()
        {
            Regex regex = new Regex(WooCompiler.RegExDefinitions.Identifier);

            it(!regex.Match("3abc").Success);
            it(!regex.Match("@abc").Success);
        }
    }
}
