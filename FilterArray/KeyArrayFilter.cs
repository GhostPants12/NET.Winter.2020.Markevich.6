using System;
using ArrayFilterExtension;
using static ArrayFilterExtension.ArrayFilter;

namespace FilterArray
{
    public static class KeyArrayFilter
    {
        /// <summary>Filters the array by key.</summary>
        /// <param name="arr">The array.</param>
        /// <param name="key">The key.</param>
        /// <returns>Sorted array.</returns>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        /// <exception cref="ArgumentOutOfRangeException">key - Key is out of range.</exception>
        public static int[] FilterArrayByKey(int[] arr, int key) => FilterOutArray(arr, key);
    }
}
