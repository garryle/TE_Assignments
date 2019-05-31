using System;
using System.Collections.Generic;
using System.Text;
using Individual.Exercises.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Individual.Exercises.Tests
{
    [TestClass]
    public class TelevisionTests
    {
        [TestMethod]
        public void InitWithCorrectDefaults()
        {
            //arrange
            Television tv = new Television();
            //act
            //assert
            Assert.AreEqual(3, tv.CurrentChannel, "Wrong initial channel");
            Assert.AreEqual(2, tv.CurrentVolume, "Wrong initial volume"); 
        }

        [TestMethod]
        public void TestChangeChannelTo18()
        {
            //arrange
            Television tv = new Television();
            
            //act
            tv.TurnOn();
            int currentChannel = tv.CurrentChannel; 
            tv.ChangeChannel(18);
            
            //assert
            Assert.AreEqual(18, tv.CurrentChannel, "18 is allowed!");
        }

      
        [DataRow(17,18)]
        [DataRow(18, 3)]
        [DataRow(3, 4)]
        [DataTestMethod]
        public void TestChannelUp(int startingChannel, int expectedResultAfterUpChannel)
        {
            //arrange
            Television tv = new Television();

            //act
            tv.TurnOn();
            tv.ChangeChannel(startingChannel);
            tv.ChannelUp();

            //assert
            Assert.AreEqual(expectedResultAfterUpChannel, tv.CurrentChannel, "Wrong channel after channel up");
          
        }


    }
}
