using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Models.PackageTest
{
    [TestFixture]
    public class PropertyName_Should
    {
        [Test]
        [TestCase("s")]
        [TestCase("soooome nameeeeeeee")]
        public void SetPassedValueCorrectly_WhenInputValueIsValid(string name)
        {
            // Arrange 
            var version = new Mock<IVersion>();

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(name, package.Name);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInputValueIsNull()
        {
            // Arrange 
            string name = null;
            var version = new Mock<IVersion>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, version.Object));
        }
    }
}
