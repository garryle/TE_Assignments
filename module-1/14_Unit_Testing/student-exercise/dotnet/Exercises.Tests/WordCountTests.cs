using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Exercises.Tests
{
    /*
     * Given an array of strings, return a Dictionary<string, int> with a key for each different string, with the value the 
     * number of times that string appears in the array.
     * 
     * ** A CLASSIC **
     * 
     * GetCount(["ba", "ba", "black", "sheep"]) → {"ba" : 2, "black": 1, "sheep": 1 }
     * GetCount(["a", "b", "a", "c", "b"]) → {"b": 2, "c": 1, "a": 2}
     * GetCount([]) → {}
     * GetCount(["c", "b", "a"]) → {"b": 1, "c": 1, "a": 1}
     * 
     */

    [TestClass]

    public class WordCountTests
    {

        [TestMethod]
        public void EmptyArray()
        {
            //Arrange
            WordCount wc = new WordCount();
            string[] ar = new string[0];
            //Act
            Dictionary<string, int> result = wc.GetCount(ar);

            //Assert
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void TestFound()
        {
            //Arrange
            WordCount wc = new WordCount();
            string[] ar = { "ab", "ab", "ab", "cd", "ab" };
            //Act
            Dictionary<string, int> result = wc.GetCount(ar);

            //Assert
            //"ab" found 4
            //"cd" found 1
            Assert.AreEqual(4, result["ab"]);
            Assert.AreEqual(1, result["cd"]);
            Assert.AreEqual(2, result.Count);
        }

    }
}
