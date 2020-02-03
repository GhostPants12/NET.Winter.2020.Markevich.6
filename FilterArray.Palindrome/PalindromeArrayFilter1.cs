using System;
using FilterArray;

namespace FilterArray
{
    public static partial class ArrayFilter
    {
        /// <summary>Filters the array by palindrome method.</summary>
        /// <param name="arr">The array.</param>
        /// <returns>Returns an array containing only palindrome elements.</returns>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentException">Array is empty</exception>
        public static int[] FilterArrayByKey(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Array is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            int[] result = new int[arr.Length];
            int resultIndex = 0;
            AddElementsToArray(result, arr, ref resultIndex);
            Array.Resize(ref result, resultIndex);
            return result;
        }

        static partial void AddElementsToArray(int[] resultingArray, int[] arr, ref int resultIndex);
    }
}
