using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]

    public class Lucky13Tests
    {
         /*
         Given an array of ints, return true if the array contains no 1's and no 3's.
         GetLucky([0, 2, 4]) → true
         GetLucky([1, 2, 3]) → false
         GetLucky([1, 2, 4]) → false
         */

        Lucky13 lucky13Test = new Lucky13();

        [DataTestMethod]

        public void Lucky13Test()
        {
            Assert.AreEqual(true, lucky13Test.GetLucky(new int[] { 0, 2, 4 }));
            Assert.AreEqual(false, lucky13Test.GetLucky(new int[] { 1, 2, 3 }));
            Assert.AreEqual(false, lucky13Test.GetLucky(new int[] { 1, 2, 4 }));
        }
    }
}


