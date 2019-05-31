using Individual.Exercises.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Individual.Exercises.Tests
{
    [TestClass]
    public class FruitTreeTests
    {
        [TestMethod]
        public void TestInit()
        {
            //arrange 
            FruitTree myTree = new FruitTree("orange", 5);

            //act 
            //assert
            Assert.AreEqual(5, myTree.PiecesOfFruitLeft, "You have the wrong number of fruit left.");
        }

        [TestMethod]
        public void PickAPieceOfFruit()
        {
            //arrange
            FruitTree ft = new FruitTree("pineapple", 90);

            //act
            bool picked = ft.PickFruit(40);

            //assert
            Assert.IsTrue(picked, "Yaint done something right");
            Assert.AreEqual(50, ft.PiecesOfFruitLeft, "You picked the wrong number of fruit");
        }

        [TestMethod]
        public void PickAPieceOfFruit_PickTooMany()
        {
            //arrange
            FruitTree ft = new FruitTree("potato", 6);

            //act
            bool picked = ft.PickFruit(7);

            //assert
            Assert.IsFalse(picked, "You cannot pick this potato");
            Assert.AreEqual(6, ft.PiecesOfFruitLeft); 

        }
        [TestMethod]
        public void PickAPieceOfFruit_PickExactCount()
        {
            //arrange
            FruitTree ft = new FruitTree("potato", 6);

            //act
            bool picked = ft.PickFruit(6);

            //assert
            Assert.IsTrue(picked, "you should be able to pick all the fruit");
            Assert.AreEqual(0, ft.PiecesOfFruitLeft);
       
        }
    }
}
