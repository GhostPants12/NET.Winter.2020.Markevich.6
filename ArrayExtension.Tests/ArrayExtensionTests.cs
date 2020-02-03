extern alias destination;
using NUnit.Framework;
using System;
using System.Linq;
using destination::FilterArray;

namespace ArrayExtension.Tests
{

    public class ArrayExtensionTests
    {
        #region FilterArrayByKeyTests
        [TestCase(new[] { 2212332, 1405644, -1236674 }, 0, ExpectedResult = new[] { 1405644 })]
        [TestCase(new[] { 53, 71, -24, 1001, 32, 1005 }, 2, ExpectedResult = new[] { -24, 32 })]
        [TestCase(new[] { -27, 173, 371132, 7556, 7243, 10017 }, 7, ExpectedResult = new[] { -27, 173, 371132, 7556, 7243, 10017 })]
        [TestCase(new[] { 7, 2, 5, 5, -1, -1, 2 }, 9, ExpectedResult = new int[0])]
        [TestCase(new[] { 15, 25, 60, 74, 189, int.MinValue, 32 }, 2, ExpectedResult = new[] { 25, int.MinValue, 32 })]
        public static int[] FilterArrayByKey_WithAllValidParameters(int[] arr, int key)
        {
            return destination::FilterArray.ArrayFilter.FilterByKey(arr, key);
        }

        [TestCase(new[] {101, 1551, 82028, 100, 1890, 1570}, ExpectedResult = new[] {101, 1551, 82028})]
        [TestCase(new[] {100, 200, 300, 400 }, ExpectedResult = new int[] { })]
        public static int[] FilterArrayByKey_WithAllValidParameters_Palindrome(int[] arr)
        {
            return FilterArray.ArrayFilter.FilterArrayByKey(arr);
        }
        [Test]
        public static void FilterArrayByKey_WithEmptyArray()=>Assert.Throws<ArgumentException>(() 
            => destination::FilterArray.ArrayFilter.FilterByKey(new int[0], 0));
        [Test]
        public static void FilterArrayByKey_WithNegativeKey() => Assert.Throws<ArgumentOutOfRangeException>(()
              => destination::FilterArray.ArrayFilter.FilterByKey(new int[] { 1, 2 }, -1));
        [Test]
        public static void FilterArrayByKey_KeyMoreThan9() => Assert.Throws<ArgumentOutOfRangeException>(()
              => destination::FilterArray.ArrayFilter.FilterByKey(new int[] { 1, 2 }, 100));
        [Test]
        public static void FilterArrayByKey_WithNullArray() => Assert.Throws<ArgumentNullException>(()
              => destination::FilterArray.ArrayFilter.FilterByKey(null, 0));
        //4 sec
        [Test]
        public static void FilterArrayByKey_WithAllValidParameters_BigArray_ForTwoMethods()
        {
            int[] arr = new int[100_000_000];
            for (int i = 0; i < arr.Length; i ++)
            {
                arr[i] = 10;
            }
            for (int i=0;i<arr.Length;i+=20_000_000)
            {
                arr[i] = 8;
            }

            int[] result = FilterArray.ArrayFilter.FilterArrayByKey(arr);
            int[] resultForKey = destination::FilterArray.ArrayFilter.FilterByKey(arr, 8);
            int[] expected = { 8, 8, 8, 8, 8 };
            Assert.AreEqual(expected, result);
            Assert.AreEqual(expected,resultForKey);
        }
        #endregion
    }
}