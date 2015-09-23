using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace WooCompiler.Test
{
    [TestClass]
    public class TokenDefinitions
    {
        

        [TestMethod]
        public void IsInteger()
        {
            Regex regex = new Regex(WooCompiler.TokenDefinition.INTEGER);

        }
    }
}
