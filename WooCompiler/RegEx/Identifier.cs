using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooCompiler
{
    /// <summary>

    /// </summary>
    public static partial class RegExDefinitions
    {
       
        public static string LowerCaseLetter = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
        public static string UpperCaseLetter = "A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z";
        public static string AllLetters = LowerCaseLetter + "|" + UpperCaseLetter;
        public static string Identifier = AllLetters + "(" + AllLetters + "|" + AnySingleDigit + ")";
    }
}
