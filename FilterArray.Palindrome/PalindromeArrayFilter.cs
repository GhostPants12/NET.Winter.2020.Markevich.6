using System;
using static ArrayFilterExtension.ArrayFilter;

namespace FilterArray.Palindrome
{
    public static class PalindromeArrayFilter
    {
        /// <summary>Filters the array by palindrome method.</summary>
        /// <param name="arr">The array.</param>
        /// <returns>Returns an array containing only palindrome elements.</returns>
        /// <exception cref="ArgumentNullException">Array is null.</exception>
        /// <exception cref="ArgumentException">Array is empty.</exception>
        public static int[] FilterArrayToPalindrome(int[] arr) => FilterOutArray(arr);
    }
}
