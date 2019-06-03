using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    /*
     Given a string, return a new string made of every other char starting with the first, so "Hello" yields "Hlo".
     GetBits("Hello") → "Hlo"	
     GetBits("Hi") → "H"	
     GetBits("Heeololeo") → "Hello"	
     */

    [TestClass]

    public class StringBitTests
    {
        StringBits stringBitTest = new StringBits();

        [DataTestMethod]

        public void StringBitTest()
        {
            Assert.AreEqual("Hlo", stringBitTest.GetBits("Hello"));
            Assert.AreEqual("H", stringBitTest.GetBits("Hi"));
            Assert.AreEqual("Hello", stringBitTest.GetBits("Heeololeo"));
        }
    }
}
