using Cosmetics.Common;
using NUnit.Framework;
using System;

namespace Cosmetics.Tests.Common.ValidatorTests
{
    [TestFixture]
    public class CheckIfNull_Should
    {
        [Test]
        public void ThrowNullRefException_WhenParamObjIsNull()
        {
            // Arrange
            object obj = null;

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfNull(obj));
        }

        [Test]
        [TestCase("random string")]
        [TestCase(1)]
        public void NotThrow_WhenParamObjIsNotNull(object input)
        {
            // Act & Assert
            Assert.DoesNotThrow(() => Validator.CheckIfNull(input));
        }
    }
}
