using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]

    public class CigarPartyTests
    {

        CigarParty cigarPartyTest = new CigarParty();

        [DataTestMethod]

        [DataRow(70, true, true)]
        [DataRow(30, false, false)]
        [DataRow(50, false, true)]

        public void CigarParty(int numOfCigars, bool isWeekend, bool expectedBool)
        {
            Assert.AreEqual(expectedBool, cigarPartyTest.HaveParty(numOfCigars, isWeekend));
        }
    }
}
