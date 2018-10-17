using System;

namespace Logic
{
    /// <summary>
    /// Represents a class that works with Int and Double types of number 
    /// and finds for them bigger number of digits of  integer value and root of n-th degree of double value.
    /// </summary>
    public static class Finder
    {
        private const int MINSENSIBLENUMBER = 12;
        private const int NOTFOUNDBIGGERNUMBER = -1;

        /// <summary>
        /// Performs a search of a closer bigger number that consists of input number's digits.  
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
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException($"The value of {nameof(number)} must be positive");
            }

            if (number < MINSENSIBLENUMBER)
            {
                return NOTFOUNDBIGGERNUMBER;
            }           

            return (HiddenFindNextBiggerNumber(number));
        }

        #region Logic Next Bigger Number
        private static int HiddenFindNextBiggerNumber(int number)
        {
            int[] numberViewInArray = ConvertIntToArray(number);

            if (numberViewInArray.Length == 2)
            {
                Swap(ref numberViewInArray[0], ref numberViewInArray[1]);
                int numberOut = ConvertArrayToInt(numberViewInArray);
                return numberOut > number ? numberOut : NOTFOUNDBIGGERNUMBER; 
            }

            int[] numberViewInSortedArray = new int[numberViewInArray.Length];
            int[] result = new int[numberViewInArray.Length];
            int i = 0;

            numberViewInArray.CopyTo(numberViewInSortedArray, 0);
            Array.Sort(numberViewInSortedArray);

            while (i < numberViewInArray.Length - 1 && IsHaveBiggerNumber(numberViewInSortedArray, numberViewInArray[i + 1]))
            {
                result[i] = numberViewInArray[i];
                int index = Array.IndexOf(numberViewInSortedArray, result[i]);
                numberViewInSortedArray[index] = -1;
                i++;
            }

            result[i] = numberViewInArray[i + 1];
            int index2 = Array.IndexOf(numberViewInSortedArray, result[i]);
            numberViewInSortedArray[index2] = -1;

            Array.Sort(numberViewInSortedArray);
            int indexMinus1 = Array.LastIndexOf(numberViewInSortedArray, -1);

            for (int j = i + 1; j < numberViewInSortedArray.Length; j++)
            {
                result[j] = numberViewInSortedArray[indexMinus1 + 1];
                indexMinus1++;
            }

            int resultNumber = ConvertArrayToInt(result);

            return resultNumber > number ? resultNumber : NOTFOUNDBIGGERNUMBER;
        }

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

        private static bool IsHaveBiggerNumber(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
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
        #endregion Logic Next Bigger Number
    }
}
