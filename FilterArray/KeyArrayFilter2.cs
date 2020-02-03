using System;
using System.Collections.Generic;
using System.Text;

namespace FilterArray
{
    public static partial class ArrayFilter
    {
        static partial void AddElementsToArray(int[] resultingArray, int[] arr, int key, ref int resultIndex)
        {
            int buf;
            for (int i = 0; i < arr.Length; i++)
            {
                buf = arr[i];
                if (Validate(buf, key))
                {
                    resultingArray[resultIndex] = buf;
                    resultIndex++;
                }
            }
        }

        private static bool Validate(int number, int key)
        {
            do
            {
                if (Math.Abs(number % 10) == key)
                {
                    return true;
                }

                number /= 10;
            }
            while (number != 0);
            return false;
        }
    }
}
