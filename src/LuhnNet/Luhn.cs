using System;
using System.Text;

namespace LuhnNet
{
    /// <summary>
    /// Provides methods to perform Luhn algorithm validations.
    /// </summary>
    public static class Luhn
    {
        private static readonly byte[] _doubledValues = new byte[] { 0, 2, 4, 6, 8, 1, 3, 5, 7, 9 };

        /// <summary>
        /// Checks if a number is valid according to the Luhn algorithm.
        /// </summary>
        /// <param name="number">Number to be checked</param>
        public static bool IsValid(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException();
            }

            var sum = Sum(number.RemoveSpaces());

            return sum > 0 && sum % 10 == 0;
        }

        /// <summary>
        /// Checks if a number is valid according to the Luhn algorithm.
        /// </summary>
        /// <param name="number">Number to be checked</param>
        [Obsolete]
        public static bool IsValid(byte[] number)
        {
            if (number == null)
            {
                throw new ArgumentNullException();
            }

            var stringNumber = new StringBuilder(); ;

            foreach (var digit in number)
            {
                if (digit != 255)
                {
                    stringNumber.Append(digit.ToString());
                }
            }

            return IsValid(stringNumber.ToString());
        }

        /// <summary>
        /// Returns the check digit that will make the number valid according to the Luhn algorithm.
        /// </summary>
        /// <param name="number">Number to be checked</param>
        public static byte CalculateCheckDigit(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentNullException();
            }

            var sum = Sum((number + "0").RemoveSpaces());
            var lastDigit = sum % 10;

            return (byte)(lastDigit == 0 ? 0 : 10 - lastDigit);
        }

        /// <summary>
        /// Returns the check digit that will make the number valid according to the Luhn algorithm.
        /// </summary>
        /// <param name="number">Number to be checked</param>
        [Obsolete]
        public static byte GetCheckDigit(byte[] number)
        {
            if (number == null)
            {
                throw new ArgumentNullException();
            }

            var stringNumber = new StringBuilder(); ;

            foreach (var digit in number)
            {
                if (digit != 255)
                {
                    stringNumber.Append(digit.ToString());
                }
            }

            return CalculateCheckDigit(stringNumber.ToString());
        }

        private static string RemoveSpaces(this string text)
        {
            return text.Replace(" ", "");
        }

        private static byte Sum(string number)
        {
            var length = number.Length;
            byte sum = 0;
            var shouldBeDoubled = true;

            while (length > 0)
            {
                if (!byte.TryParse(number[--length].ToString(), out byte digit))
                {
                    throw new Exception($"Invalid character found at position {length}.");
                }

                sum += (shouldBeDoubled ^= true) ? _doubledValues[digit] : digit;
            }

            return sum;
        }
    }
}
