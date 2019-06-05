using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD.Classes;

namespace TDD.Tests.Classes
{
    [TestClass]
    public class KataRomanNumeralTests
    {
        KataRomanNumeral kata;

        [TestInitialize]
        public void Initialize()
        {
            kata = new KataRomanNumeral(); 
        }

        [TestMethod]
        public void Test_Ones()
        {
            Assert.AreEqual("I", kata.GetRomanNumeral(1));
            Assert.AreEqual("II", kata.GetRomanNumeral(2));
            Assert.AreEqual("III", kata.GetRomanNumeral(3));
        }

        [TestMethod]
        public void Test_Fives()
        {
            Assert.AreEqual("V", kata.GetRomanNumeral(5));
            Assert.AreEqual("VI", kata.GetRomanNumeral(6));
            Assert.AreEqual("VII", kata.GetRomanNumeral(7));
        }

        [TestMethod]
        public void Test_Tens()
        {
            Assert.AreEqual("X", kata.GetRomanNumeral(10));
            Assert.AreEqual("XI", kata.GetRomanNumeral(11));
            Assert.AreEqual("XV", kata.GetRomanNumeral(15));
            Assert.AreEqual("XVII", kata.GetRomanNumeral(17));
            Assert.AreEqual("XXXVI", kata.GetRomanNumeral(36));
        }

        [TestMethod]
        public void Test_Fifties()
        {
            Assert.AreEqual("L", kata.GetRomanNumeral(50));
            Assert.AreEqual("LXVI", kata.GetRomanNumeral(66));
            Assert.AreEqual("LXXXVII", kata.GetRomanNumeral(87));         
        }


        [TestMethod]
        public void Test_Rest()
        {
            Assert.AreEqual("C", kata.GetRomanNumeral(100));
            Assert.AreEqual("CLXVI", kata.GetRomanNumeral(166));
            Assert.AreEqual("D", kata.GetRomanNumeral(500));
            Assert.AreEqual("M", kata.GetRomanNumeral(1000));
            Assert.AreEqual("MDCCLXVI", kata.GetRomanNumeral(1766)); 
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            Assert.AreEqual("IV", kata.GetRomanNumeral(4));
            Assert.AreEqual("IX", kata.GetRomanNumeral(9));
            Assert.AreEqual("XXIX", kata.GetRomanNumeral(29));
            Assert.AreEqual("XL", kata.GetRomanNumeral(40));
            Assert.AreEqual("XC", kata.GetRomanNumeral(90));
            Assert.AreEqual("CD", kata.GetRomanNumeral(400));
            Assert.AreEqual("CM", kata.GetRomanNumeral(900));
            
        }

        [TestMethod]
        public void Test_Random()
        {          
            Assert.AreEqual("MMCMXCIX", kata.GetRomanNumeral(2999));
            Assert.AreEqual("CDXLIV", kata.GetRomanNumeral(444));
        }
    }
}
