using System;

namespace Logic
{
    /// <summary>
    /// Represents a class that works with Int and Double types of number 
    /// and finds for them bigger number of digits of  integer value and root of n-th degree of double value.
    /// </summary>
    public static class Finder
    {
        private static readonly int MINSENSIBLENUMBER;
        private static readonly int MINDEGREE;
        private static readonly int MINACCURANCY;
        private static readonly int MAXACCURANCY;

        static Finder()
        {
            MINSENSIBLENUMBER = 12;
            MINDEGREE = 1;
            MINACCURANCY = 0;
            MAXACCURANCY = 1;
        }

        /// <summary>
        /// Performs the search of a closer bigger number that consists of input number's digits.  
        /// </summary>
        /// <param name="number">
        /// The number for which the search will be executed.
        /// </param>
        /// <returns>
        /// A suitable number  - if it was found.
        /// -1 - if  a suitable number was not found.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the input number is negative.
        /// </exception>
        public static int? FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(number)} must be positive");
            }

            if (number < MINSENSIBLENUMBER)
            {
                return null;
            }           

            return HiddenFindNextBiggerNumber(number);
        }

        /// <summary>
        /// Performs the calculation of the root of a given degree to the required accuracy for a real number by Newton's method.
        /// </summary>
        /// <param name="number"> 
        /// The real number for which calculation will be.</param>
        /// <param name="degree">
        /// The required degree of root.</param>
        /// <param name="accuracy">
        /// The required accuracy.
        /// </param>
        /// <returns>
        /// The nTh degree root of number. 
        /// </returns>
        public static double FindNthRoot(double number, int degree, double accuracy)
        {
            CheckInputData(number, degree, accuracy);

            double initialGuess = number;
            double nextX = FindNextX(number, initialGuess, degree);
            double currentX = initialGuess;

            while (Math.Abs(nextX - currentX) > accuracy)
            {
                currentX = nextX;
                nextX = FindNextX(number, currentX, degree);
            }

            return nextX;
        }

        #region Core Nth Root By Newton's method
        private static double FindNextX(double number, double currentX, int degree)
        {
            return (1.0 / degree) * (((degree - 1) * currentX) + (number / Math.Pow(currentX, degree - 1)));  
        }

        private static void CheckInputData(double number, int degree, double accuracy)
        {
            if (degree < MINDEGREE)
            {
                throw new ArgumentException($"The value of {nameof(degree)} can not be less than {MINDEGREE}");
            }

            if (accuracy <= MINACCURANCY || accuracy >= MAXACCURANCY)
            {
                throw new ArgumentException($"The value of {nameof(accuracy)} must be in range betwen {MINACCURANCY} - {MAXACCURANCY}");
            }

            if (number <= 0 && (degree & 1) == 0)
            {
                throw new ArgumentException("The root can not be found when degree is even and number is less than 0.");
            }
        }

        #endregion Nth Root By Newton's method

        #region Core Next Bigger Number
        private static int? HiddenFindNextBiggerNumber(int number)
        {
            int[] numberViewInArray = ConvertIntToArray(number);
            bool isSort = false;

            for (int i = 0; i < numberViewInArray.Length - 1; i++)
            {
                if (!IsHaveBiggerNumber(numberViewInArray, numberViewInArray[i + 1], i + 1) && !isSort)
                {
                    Swap(ref numberViewInArray[i], ref numberViewInArray[i + 1]);
                    Array.Sort(numberViewInArray, i + 1, numberViewInArray.Length - ++i);
                    isSort = true;
                }
            }

            int? resultNumber = ConvertArrayToInt(numberViewInArray);

            return resultNumber > number ? resultNumber : null;
        }
        #endregion Next Bigger Number

        #region Utils
        private static int ConvertArrayToInt(int[] array)
        {
            int digitOfNumber = (int)Math.Pow(10, array.Length - 1);
            int result = 0;
            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] * digitOfNumber;
                digitOfNumber = digitOfNumber / 10;
            }

            return result;
        }

        private static int[] ConvertIntToArray(int number)
        {
            string numberViewInString = number.ToString();
            int[] numberViewInArray = new int[numberViewInString.Length];

            for (int i = numberViewInArray.Length - 1; i >= 0; i--)
            {
                numberViewInArray[i] = number % 10;
                number = number / 10;
            }

            return numberViewInArray;            
        }

        private static bool IsHaveBiggerNumber(int[] array, int number, int startIndex)
        {
            for (int i = startIndex; i < array.Length; i++)
            {
                if (array[i] > number)
                {
                    return true;
                }
            }

            return false;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion Utils
    }
}
