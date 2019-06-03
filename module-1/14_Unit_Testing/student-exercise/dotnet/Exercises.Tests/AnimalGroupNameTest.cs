using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercises.Tests
{
    [TestClass]

    public class AnimalGroupNameTest
    {
        [DataRow("rhino", "Crash")]
        [DataRow("giraffe", "Tower")]
        [DataRow("elephant", "Herd")]
        [DataRow("lion", "Pride")]
        [DataRow("crow", "Murder")]
        [DataRow("pigeon", "Kit")]
        [DataRow("flamingo", "Pat")]
        [DataRow("deer", "Herd")]
        [DataRow("dog", "Pack")]
        [DataRow("crocodile", "Float")]

        [DataTestMethod]

        public void AnimalGroupTest(string animalName, string expectedAnimalHerd)
        {
            AnimalGroupName animalHerdTest = new AnimalGroupName();
            string animalHerd = animalHerdTest.GetHerd(animalName);
            Assert.AreEqual(expectedAnimalHerd, animalHerd, "Your animals are in the incorrect herd.");
        }
    }
}
