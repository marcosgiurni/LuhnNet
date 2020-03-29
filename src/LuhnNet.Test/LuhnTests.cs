using NUnit.Framework;
using System.Linq;

namespace LuhnNet.Test
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void IsValid_NullString_ArgumentNullException()
        {
            string number = null;
            Assert.That(() => Luhn.IsValid(number), Throws.ArgumentNullException);
        }

        [Test]
        public void IsValid_EmptyString_ArgumentNullException()
        {
            Assert.That(() => Luhn.IsValid(""), Throws.ArgumentNullException);
        }

        [Test]
        public void IsValid_WhiteSpaceString_ArgumentNullException()
        {
            Assert.That(() => Luhn.IsValid(" "), Throws.ArgumentNullException);
        }

        [Test]
        public void IsValid_InvalidString_Exception()
        {
            Assert.That(() => Luhn.IsValid("abc"), Throws.Exception);
        }

        [TestCase("5555 6666 7777 8884", true)]
        [TestCase("5555 6666 7777 8888", false)]
        [TestCase("4012001037141112", true)]
        [TestCase("4012001037141111", false)]
        [TestCase("376449047333005", true)]
        [TestCase("376449047333000", false)]
        [TestCase("6362970000457013", true)]
        [TestCase("6362970000457012", false)]
        [TestCase("36490102462661", true)]
        [TestCase("36490102462660", false)]
        [TestCase("6370950000000005", true)]
        [TestCase("6370950000000000", false)]
        [TestCase("18", true)]
        [TestCase("0", false)]
        public void IsValid_ValidNumber_TrueOrFalse(string number, bool expected)
        {
            var isValid = Luhn.IsValid(number);

            Assert.That(isValid, Is.EqualTo(expected));
        }

        [Test]
        public void IsValid_NullByteArray_ArgumentNullException()
        {
            byte[] number = null;
            Assert.That(() => Luhn.IsValid(number), Throws.ArgumentNullException);
        }

        [Test]
        public void IsValid_EmptyByteArray_ArgumentNullException()
        {
            byte[] number = new byte[0];

            Assert.That(() => Luhn.IsValid(""), Throws.ArgumentNullException);
        }

        [TestCase("5555 6666 7777 8884", true)]
        [TestCase("5555 6666 7777 8888", false)]
        [TestCase("4012001037141112", true)]
        [TestCase("4012001037141111", false)]
        [TestCase("376449047333005", true)]
        [TestCase("376449047333000", false)]
        [TestCase("6362970000457013", true)]
        [TestCase("6362970000457012", false)]
        [TestCase("36490102462661", true)]
        [TestCase("36490102462660", false)]
        [TestCase("6370950000000005", true)]
        [TestCase("6370950000000000", false)]
        [TestCase("18", true)]
        [TestCase("0", false)]
        public void IsValid_ValidByteArray_TrueOrFalse(string number, bool expected)
        {
            var byteArray = Enumerable.ToArray(number.ToCharArray().Select(n => (byte)char.GetNumericValue(n)));

            var isValid = Luhn.IsValid(byteArray);

            Assert.That(isValid, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateCheckDigit_NullString_ArgumentNullException()
        {
            string number = null;
            Assert.That(() => Luhn.CalculateCheckDigit(number), Throws.ArgumentNullException);
        }

        [Test]
        public void CalculateCheckDigit_EmptyString_ArgumentNullException()
        {
            Assert.That(() => Luhn.CalculateCheckDigit(""), Throws.ArgumentNullException);
        }

        [Test]
        public void CalculateCheckDigit_WhiteSpaceString_ArgumentNullException()
        {
            Assert.That(() => Luhn.CalculateCheckDigit(" "), Throws.ArgumentNullException);
        }

        [Test]
        public void CalculateCheckDigit_InvalidString_Exception()
        {
            Assert.That(() => Luhn.CalculateCheckDigit("abc"), Throws.Exception);
        }

        [TestCase("5555 6666 7777 888", 4)]
        [TestCase("401200103714111", 2)]
        [TestCase("37644904733300", 5)]
        [TestCase("636297000045701", 3)]
        [TestCase("3649010246266", 1)]
        [TestCase("637095000000000", 5)]
        [TestCase("1", 8)]
        public void CalulateCheckDigit_ValidNumber_CheckDigit(string number, byte expected)
        {
            var checkDigit = Luhn.CalculateCheckDigit(number);

            Assert.That(checkDigit, Is.EqualTo(expected));
        }

        [Test]
        public void GetCheckDigit_NullByteArray_ArgumentNullException()
        {
            byte[] number = null;
            Assert.That(() => Luhn.GetCheckDigit(number), Throws.ArgumentNullException);
        }

        [Test]
        public void GetCheckDigit_EmptyByteArray_ArgumentNullException()
        {
            byte[] number = new byte[0];

            Assert.That(() => Luhn.GetCheckDigit(number), Throws.ArgumentNullException);
        }


        [TestCase("5555 6666 7777 888", 4)]
        [TestCase("401200103714111", 2)]
        [TestCase("37644904733300", 5)]
        [TestCase("636297000045701", 3)]
        [TestCase("3649010246266", 1)]
        [TestCase("637095000000000", 5)]
        [TestCase("1", 8)]
        public void GetCheckDigit_ValidNumber_CheckDigit(string number, byte expected)
        {
            var byteArray = Enumerable.ToArray(number.ToCharArray().Select(n => (byte)char.GetNumericValue(n)));

            var checkDigit = Luhn.GetCheckDigit(byteArray);

            Assert.That(checkDigit, Is.EqualTo(expected));
        }
    }
}