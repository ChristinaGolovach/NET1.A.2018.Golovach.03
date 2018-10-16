using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// 
    /// </summary>
    public static class Finder
    {
        private const int MIN2DIGITNUMBER = 10;

        private static int[] ConvertIntToArray(int number)
        {
            if (number < MIN2DIGITNUMBER)
            {
                return new int[] { number };
            }

            string numberViewInString = number.ToString();
            int[] numberViewInArray = new int[numberViewInString.Length];

            for (int i = numberViewInArray.Length-1; i>=0; i--)
            {
                numberViewInArray[i] = number % 10;
                number = number / 10;
            }

            return numberViewInArray;            
        }
    }
}
