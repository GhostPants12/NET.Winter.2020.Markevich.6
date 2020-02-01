using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TransformerExtension
{
    public class Transformer
    {
        /// <summary>Dictionary that contains word match for a character.</summary>
        private readonly Dictionary<char, string> characterToWord = new Dictionary<char, string>
        {
            { '+', "plus" },
            { '-', "minus" },
            { '.', "point" },
            { '0', "zero" },
            { '1', "one" },
            { '2', "two" },
            { '3', "three" },
            { '4', "four" },
            { '5', "five" },
            { '6', "six" },
            { '7', "seven" },
            { '8', "eight" },
            { '9', "nine" },
            { 'E', "E" },
        };

        /// <summary>Transforms to words.</summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value contains unpredictable symbols.</exception>
        /// <returns>Returns the string representation of a value.</returns>
        public string TransformToWords(double value)
        {
            if (value.ToString(CultureInfo.InvariantCulture) == double.Epsilon.ToString(CultureInfo.InvariantCulture))
            {
                return "Epsilon";
            }

            if (double.IsNaN(value))
            {
                return "Not a number";
            }

            if (double.IsPositiveInfinity(value))
            {
                return "Positive infinity";
            }

            if (double.IsNegativeInfinity(value))
            {
                return "Negative infinity";
            }

            if (value == 0)
            {
                return "zero";
            }

            int inconsistencyCount;
            string outString;
            StringBuilder result = new StringBuilder(string.Empty);
            string valueAsString = value.ToString(CultureInfo.InvariantCulture);
            foreach (char ch in valueAsString)
            {
                inconsistencyCount = 0;
                foreach (KeyValuePair<char, string> keyValue in this.characterToWord)
                {
                    if (ch == keyValue.Key)
                    {
                        result.Append($"{keyValue.Value} ");
                    }
                    else
                    {
                        inconsistencyCount++;
                    }
                }

                if (inconsistencyCount == this.characterToWord.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value contains unpredictable symbols.");
                }
            }

            outString = result.ToString();
            return outString.Substring(0, outString.Length - 1);
        }
    }
}
