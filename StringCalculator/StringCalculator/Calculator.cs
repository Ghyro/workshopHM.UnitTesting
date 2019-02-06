using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator
{
    /// <summary>
    /// Workshop Day 3. Unit testing
    /// The simple string calculator which helps us to learn how to work unit tests
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Add some numbers which execute sum operation
        /// </summary>
        /// <param name="number">Input string numbers</param>
        /// <returns>Sum of numbers</returns>
        public int Add (string number)
        {
            // Null
            if (number is null)
            {
                throw new ArgumentNullException(nameof(number));
            }

            // Empty string or null
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            // Replaces and splits elements
            var stringNumbersArray = number.Replace('\n', ',').Split(',');

            // Delimiter
            if (stringNumbersArray[0].StartsWith("//"))
            {
                var delimiter = Convert.ToChar(stringNumbersArray[0].Remove(0, 2));

                stringNumbersArray = stringNumbersArray[1].Split(delimiter);
            }

            // Converts to int array (var)
            var numberArray = stringNumbersArray.Select(int.Parse).ToArray();

            // Validate (negative numbers)
            ValidateNegativeNumber(numberArray);

            // Returns sum
            return numberArray
                .Where(x => x <= 1000)
                .Sum(x => x);
        }

        /// <summary>
        /// Checks nubmers for negatives and return message
        /// </summary>
        /// <param name="numberArray">Input array</param>
        public static void ValidateNegativeNumber(int[] numberArray)
        {
            if (numberArray.Any(x => x < 0))
            {
                throw new ArgumentException($"negatives not allowed {string.Join(" ", numberArray.Where(x => x < 0))}");
            }
        }
    }
}
