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
        NonStart nonStartTest = new NonStart();

        [DataRow("Hello", "There", "ellohere")]
        [DataRow("java", "code", "avaode")]
        [DataRow("shotl", "java", "hotlava")]

        [DataTestMethod]

        public void NonStartTest(string string1, string string2, string output)
        {
            Assert.AreEqual("ellohere", nonStartTest.GetPartialString("Hello", "There"));
            Assert.AreEqual("avaode", nonStartTest.GetPartialString("java", "code"));
            Assert.AreEqual("hotlava", nonStartTest.GetPartialString("shotl", "java"));
        }
    }
}
