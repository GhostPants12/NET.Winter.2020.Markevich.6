using System;
using FilterArray;

namespace FilterArray
{
    public static partial class ArrayFilter
    {
        /// <summary>Filters the array by key.</summary>
        /// <param name="arr">The array.</param>
        /// <param name="key">The key.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">key - Key is out of range.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        public static int[] FilterByKey(int[] arr, int key)
        {
            if (arr == null)
            {
                throw new ArgumentNullException($"{nameof(arr)} is null.");
            }

            if (key < 0 || key > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(key), "Key is out of range");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            int[] result = new int[arr.Length];
            int resultIndex = 0;
            AddElementsToArray(result, arr, key, ref resultIndex);
            Array.Resize(ref result, resultIndex);
            return result;
        }

        static partial void AddElementsToArray(int[] resultingArray, int[] arr, int key, ref int resultIndex);
    }
}