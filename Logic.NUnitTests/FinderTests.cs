using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Logic.NUnitTests
{
    [TestFixture]
    public class FinderTests
    {
        #region FindNextBiggerNumber tests

        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        public int FindNextBiggerNumber_PassNumberForWhichBigerNumberExists_ReturnBiggerNumber(int number)
            => Finder.FindNextBiggerNumber(number);

        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]
        [TestCase(2, ExpectedResult = -1)]
        public int FindNextBiggerNumber_PassNumberForWhichBigerNumberDoesNotExist_ReturnBiggerNotFoundValue(int number)
            => Finder.FindNextBiggerNumber(number);

        [TestCase(-1)]
        public void FindNextBiggerNumber_PassNegativeNumber_TrownException(int number)
            => Assert.Throws<ArgumentOutOfRangeException>(() => Finder.FindNextBiggerNumber(number));

        #endregion FindNextBiggerNumber tests

        #region FindNthRoot tests

        [TestCase(1, 5, 0.0001, 1)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.001, 3, 0.0001, 0.1)]
        [TestCase(0.04100625, 4, 0.0001, 0.45)]
        [TestCase(8, 3, 0.0001, 2)]
        [TestCase(0.0279936, 7, 0.0001,  0.6)]
        [TestCase(0.0081, 4, 0.1, 0.3)]
        [TestCase(-0.008, 3, 0.1, -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, 0.545)]
        public void FindNthRoot_PassCorectData_ReturnRootOfGivenDegreeAndAccurancy(double number, int degree, double accuracy, double expectedResult)
            => Assert.AreEqual(expectedResult, Finder.FindNthRoot(number, degree, accuracy), accuracy);

        [TestCase(-0.001, 2, 0.0001)]
        public void FindNthRoot_PassNegativeNumberAndEvenDegree_TrownException(double number, int degree, double accuracy)
            => Assert.Throws<ArgumentException>(() => Finder.FindNthRoot(number, degree, accuracy));

        [TestCase(0.001, -2, 0.0001)]
        public void FindNthRoot_PassNegativeDegree_TrownException(double number, int degree, double accuracy)
            => Assert.Throws<ArgumentException>(() => Finder.FindNthRoot(number, degree, accuracy));

        [TestCase(0.001, 2, -0.0001)]
        public void FindNthRoot_PassNegativeAccurancy_TrownException(double number, int degree, double accuracy)
            => Assert.Throws<ArgumentException>(() => Finder.FindNthRoot(number, degree, accuracy));
        #endregion FindNthRoot tests
    }
}
