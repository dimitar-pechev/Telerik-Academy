using System;
using Cosmetics.Common;
using NUnit.Framework;

namespace Cosmetics.Tests.Common.ValidatorTests
{
    [TestFixture]
    public class CheckIfStringLengthIsValid_Should
    {
        [Test]
        [TestCase("short")]
        [TestCase("loooooooooooooooong")]
        public void ThrowIndexOutOfRangeException_WhenTheInputStringIsOutOfThePermittedRange(string text)
        {
            // Arrange
            var max = 17;
            var min = 6;

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }

        [Test]
        [TestCase("not short")]
        [TestCase("not too looong")]
        public void NotThrow_WhenTheInputStringIsInsideThePermittedBounderies(string text)
        {
            // Arrange
            var max = 14;
            var min = 9;

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringLengthIsValid(text, max, min));
        }
    }
}
