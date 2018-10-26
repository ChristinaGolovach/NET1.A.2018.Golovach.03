using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logic.Tests
{
    [TestClass]
    public class FinderTests
    {
        public TestContext TestContext { get; set; }

        #region FindNextBiggerNumber tests

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Finder_FindNextBiggerNumber_Tests.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\Finder_FindNextBiggerNumber_Tests.xml")]
        [TestMethod]
        public void FindNextBiggerNumber_TakePositiveNumber_ReturnedBiggerNumber()
        {
            // Arange
            int number = Convert.ToInt32(TestContext.DataRow["number"]);
            int expectedResult = Convert.ToInt32(TestContext.DataRow["expectedResult"]);

            // Act
            int? result = Finder.FindNextBiggerNumber(number);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindNextBiggerNumber_PassNegativeNumber_ThrowException()
            => Finder.FindNextBiggerNumber(-1);

        #endregion #region FindNextBiggerNumber tests

        #region FindNthRoot tests

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\Finder_FindNthRoot_Tests.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("Logic.Tests\\Finder_FindNthRoot_Tests.xml")]
        [TestMethod]
        public void FindNthRoot_PassCorrectDataFromXML_ReturnRoot()
        {
            // Arange
            double number = Convert.ToDouble(TestContext.DataRow["number"]);
            int degree = Convert.ToInt32(TestContext.DataRow["degree"]);
            double accuracy = Convert.ToDouble(TestContext.DataRow["accuracy"]);
            double expectedResult = Convert.ToDouble(TestContext.DataRow["expectedResult"]);

            // Act
            double result = Finder.FindNthRoot(number, degree, accuracy);

            // Assert
            Assert.AreEqual(expectedResult, result, accuracy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_PassNegativeDegreOfRoot_ThrownException()
            => Finder.FindNthRoot(0.001, -2, 0.0001);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_PassOutOfRangeAccurancy_ThrownException()
             => Finder.FindNthRoot(0.01, 2, -1);

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FindNthRoot_PassNegativeNumberAndEvenRoot_ThrownException()
            => Finder.FindNthRoot(-0.01, 2, 0.0001);

        #endregion FindNthRoot tests
    }
}
