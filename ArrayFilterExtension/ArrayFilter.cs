using System;
using System.ComponentModel.DataAnnotations;

namespace ArrayFilterExtension
{
    public static class ArrayFilter
    {
        /// <summary>Filters out the array.</summary>
        /// <param name="arr">The array.</param>
        /// <param name="key">The key.</param>
        /// <returns>Sorted array depending on the input.</returns>
        public static int[] FilterOutArray(int[] arr, int? key = null)
        {
            CheckParameters(arr, key);
            int buf;
            int[] result = new int[arr.Length];
            int resultIndex = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                buf = arr[i];
                if (Validate(buf, key))
                {
                    result[resultIndex] = buf;
                    resultIndex++;
                }
            }

            Array.Resize(ref result, resultIndex);
            return result;
        }

        /// <summary>Checks if the parameters are correct.</summary>
        /// <param name="arr">The array.</param>
        /// <param name="key">The key.</param>
        /// <exception cref="System.ArgumentNullException">arr - Array is null.</exception>
        /// <exception cref="System.ArgumentException">Array is empty.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">key - Key is out of range.</exception>
        private static void CheckParameters(int[] arr, int? key)
        {
            if (arr == null)
            {
                throw new ArgumentNullException(nameof(arr), "Array is null.");
            }

            if (arr.Length == 0)
            {
                throw new ArgumentException("Array is empty");
            }

            if (key != null)
            {
                if (key < 0 || key > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(key), "Key is out of range");
                }
            }
        }

        /// <summary>Validates the specified value.</summary>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        /// <returns>Returns if the value is palindrome or it contains key.</returns>
        private static bool Validate(int value, int? key)
        {
            if (key == null)
            {
                return IsPalindrome(value);
            }

            return ContainsKey(value, key);
        }

        /// <summary>Determines whether the specified value is palindrome.</summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is palindrome; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">value - Value cannot be less than zero.</exception>
        private static bool IsPalindrome(int value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be less than zero");
            }

            int valueCopy = value;
            int decimalPlaces = 1;
            int tenDivider;
            while (valueCopy / 10 != 0)
            {
                valueCopy /= 10;
                decimalPlaces++;
            }

            if (decimalPlaces == 1)
            {
                return true;
            }

            if (decimalPlaces == 2)
            {
                if (value / 10 == value % 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            tenDivider = (int)Math.Pow(10, decimalPlaces - 1);
            if (value / tenDivider == value % 10)
            {
                if ((value % tenDivider) / (tenDivider / 10) == 0)
                {
                    if ((value / 10) % 10 == 0)
                    {
                        return IsPalindrome(((value % tenDivider) / 10) + (tenDivider / 100) + 1);
                    }
                    else
                    {
                        return false;
                    }
                }

                return IsPalindrome((value % tenDivider) / 10);
            }
            else
            {
                return false;
            }
        }

        /// <summary>Determines whether the specified value contains key.</summary>
        /// <param name="value">The value.</param>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified value contains key; otherwise, <c>false</c>.</returns>
        private static bool ContainsKey(int value, int? key)
        {
            do
            {
                if (Math.Abs(value % 10) == key)
                {
                    return true;
                }

                value /= 10;
            }
            while (value != 0);
            return false;
        }
    }
}
