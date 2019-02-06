using System;
using NUnit.Framework;
using StringCalculator;

namespace StringCalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator = new Calculator();

        [Test]
        [TestCase(0, "")]
        [TestCase(1, "1")]
        [TestCase(3, "1,2")]
        [TestCase(10, "5,5")]
        [TestCase(6, "1\n2,3")]
        [TestCase(3, "//;\n1;2")]
        [TestCase(2, "//;\n2;1001")]
        public void Add_Number_PositiveTest(int expected, string number)
        {
            // Arrange

            // Act

            // Assert
            Assert.AreEqual(expected, calculator.Add(number));
        }

        [Test]
        [TestCase(null)]
        public void Add_Number_NegativeTest_ReturnNull(string number)
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<ArgumentNullException>(() => calculator.Add(number));
        }

        [Test]
        [TestCase("-2,-3")]
        public void Add_Number_NegativeTest_ReturnException(string number)
        {
            // Arrange

            // Act
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add(number));

            // Assert
            Assert.AreEqual("negatives not allowed -2 -3", exception.Message);
        }

        [Test]
        [TestCase("//;\n-1;-2")]
        public void Add_Number_NegativeTest_ReturnExceptionWithDelimiter(string number)
        {
            // Arrange;

            // Act
            var exception = Assert.Throws<ArgumentException>(() => calculator.Add(number));

            // Assert
            Assert.AreEqual("negatives not allowed -1 -2", exception.Message);
        }
    }
}
