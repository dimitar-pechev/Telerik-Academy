using NUnit.Framework;
using System;

namespace Academy.Tests.Models.Abstractions
{
    [TestFixture]
    public class UserTests
    {
        [Test]
        [TestCase("aaa")]
        [TestCase("addskdjasks")]
        [TestCase("0123456789123456")]
        public void Constructor_ShouldNotThrow_WhenInputParamsAreValid(string username)
        {
            // Arrnage & Act & Assert
            Assert.DoesNotThrow(() => new UserMock(username));
        }

        [Test]
        [TestCase("aaa")]
        [TestCase("addskdjasks")]
        [TestCase("0123456789123456")]
        public void Constructor_ShouldCorrectlyAssignValues_WhenInputParamsAreValid(string username)
        {
            // Arrnage & Act
            var user = new UserMock(username);

            // Assert
            Assert.AreEqual(username, user.Username);
        }

        [Test]
        [TestCase("a")]
        [TestCase("01234567891234567")]
        [TestCase("")]
        [TestCase(null)]
        public void Constructor_ShouldThrow_WhenInputParamsAreInvalid(string username)
        {
            // Arrnage & Act & Assert
            Assert.Throws<ArgumentException>(() => new UserMock(username));
        }
    }
}
