using Moq;
using NUnit.Framework;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Tests.Models.PackageTest
{
    [TestFixture]
    public class PropertyVersion_Should
    {
        [Test]
        public void SetPassedValueCorrectly_WhenInputValueIsValid()
        {
            // Arrange 
            string name = "some name";
            var version = new Mock<IVersion>();

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreSame(version.Object, package.Version);
        }

        [Test]
        public void ThrowArgumentNullException_WhenInputValueIsNull()
        {
            // Arrange 
            string name = "Some cool name";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Package(name, null));
        }
    }
}
