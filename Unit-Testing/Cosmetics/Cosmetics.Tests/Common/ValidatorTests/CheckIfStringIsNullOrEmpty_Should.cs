using System;
using Cosmetics.Common;
using NUnit.Framework;

namespace Cosmetics.Tests.Common.ValidatorTests
{
    [TestFixture]
    public class CheckIfStringIsNullOrEmpty_Should
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullRefException_WhenTextParamIsNullOrEmpty(string text)
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }

        [Test]
        public void NotThrow_WhenTextParamIsNotNullOrEmpty()
        {
            // Arrange
            var text = "random string";

            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfStringIsNullOrEmpty(text));
        }
    }
}
