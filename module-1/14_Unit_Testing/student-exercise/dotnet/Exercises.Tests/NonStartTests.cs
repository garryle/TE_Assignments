using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
         /*
         Given 2 strings, return their concatenation, except omit the first char of each. The strings will 
         be at least length 1.
         GetPartialString("Hello", "There") → "ellohere"
         GetPartialString("java", "code") → "avaode"	
         GetPartialString("shotl", "java") → "hotlava"	
         */

    [TestClass]

    public class NonStartTests
    {
        [DataRow("Hello", "There", "ellohere")]
        [DataRow("java", "code", "avaode")]
        [DataRow("shot1", "java", "hotlava")]

        [DataTestMethod]

        public void NonStartTest(string string1, string string2, string output)
        {

        }
    }
}
