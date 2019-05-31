using System;
using System.Collections.Generic;
using System.Text;
using Individual.Exercises.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Individual.Exercises.Tests
{
    [TestClass]
    public class HomeworkAssignmentTests
    {
        [TestMethod]
        public void TestInit()
        {
            //arrange
            HomeworkAssignment hw = new HomeworkAssignment(90, "Alfonso");

            //act 

            //assert
            Assert.AreEqual(90, hw.PossibleMarks, "possible marks wrong!!!");
            Assert.AreEqual("Alfonso", hw.SubmitterName, "the name is wrong");
        }

        [TestMethod]
        public void ScoreAssignment_90_IsAnA()
        {
            //arrange 
            HomeworkAssignment hw = new HomeworkAssignment(100, "Fresh Prince of Belair");

            //act
            hw.TotalMarks = 90;

            //assert
            Assert.AreEqual("A", hw.LetterGrade); 
        }

        [DataTestMethod]
        [DataRow(90,"A")]
        [DataRow(89, "B")]
        [DataRow(80, "B")]
        [DataRow(79, "C")]
        [DataRow(70, "C")]
        [DataRow(69, "D")]
        [DataRow(60, "D")]
        [DataRow(40, "F")]
        [DataRow(59, "F")]
        [DataRow(0, "F")]
        public void ScoreAssignments(int receivedScore, string expectedLetterGrade)
        {
            //arrange 
            HomeworkAssignment hw = new HomeworkAssignment(100, "Fresh Prince of Belair");

            //act
            hw.TotalMarks = receivedScore;

            //assert
            Assert.AreEqual(expectedLetterGrade, hw.LetterGrade);
        }

    }
}
