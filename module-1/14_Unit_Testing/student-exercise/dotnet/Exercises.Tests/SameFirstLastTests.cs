using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    /*
     Given an array of ints, return true if the array is length 1 or more, and the first element and
     the last element are equal.
     IsItTheSame([1, 2, 3]) → false
     IsItTheSame([1, 2, 3, 1]) → true
     IsItTheSame([1, 2, 1]) → true
     */

    [TestClass]

    public class SameFirstLastTests
    {
        SameFirstLast sameFirstLastTest = new SameFirstLast();

        [DataTestMethod]

        public void SameFirstLastTest()
        {
            Assert.AreEqual(false, sameFirstLastTest.IsItTheSame(new int[] { 1, 2, 3 }));
            Assert.AreEqual(true, sameFirstLastTest.IsItTheSame(new int[] { 1, 2, 3, 1}));
            Assert.AreEqual(true, sameFirstLastTest.IsItTheSame(new int[] { 1, 2, 1 }));
        }
    }
}
