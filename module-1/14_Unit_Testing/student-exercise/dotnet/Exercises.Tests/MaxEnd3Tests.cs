using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]

    public class MaxEnd3Tests
    {
        /*
         Given an array of ints length 3, figure out which is larger between the first and last elements 
         in the array, and set all the other elements to be that value. Return the changed array.
         MakeArray([1, 2, 3]) → [3, 3, 3]
         MakeArray([11, 5, 9]) → [11, 11, 11]
         MakeArray([2, 11, 3]) → [3, 3, 3]
         */

        MaxEnd3 maxEnd3Test = new MaxEnd3();

        [DataTestMethod]

        public void MaxEndTest()
        {
            CollectionAssert.AreEqual(new int[] { 3, 3, 3}, maxEnd3Test.MakeArray(new int[] { 1, 2, 3 }));
            CollectionAssert.AreEqual(new int[] { 11, 11, 11}, maxEnd3Test.MakeArray(new int[] { 11, 5, 9}));
            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, maxEnd3Test.MakeArray(new int[] { 2, 11, 3 }));
        }
    }
}
