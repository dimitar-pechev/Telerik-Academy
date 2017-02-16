using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Tests.Models.PackageTest
{
    [TestFixture]
    public class Equals_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenObjOtherIsNull()
        {
            // Arrange 
            var nameFirst = "some name";
            var firstVersion = new Mock<IVersion>();

            var package = new Package(nameFirst, firstVersion.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.Equals(null));
        }

        [Test]
        public void NotThrow_WhenObjOtherIsValid()
        {
            // Arrange
            var name = "some name";
            var version = new Mock<IVersion>();
            var nameSecond = "some name";
            var secondVersion = new Mock<IVersion>();

            var package = new Package(name, version.Object);
            var secondPackage = new Package(nameSecond, secondVersion.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => package.Equals(secondPackage));
        }

        [Test]
        public void ThrowArgumentException_WhenObjOtherIsNotOfTypeIPackage()
        {
            // Arrange 
            var nameFirst = "some name";
            var firstVersion = new Mock<IVersion>();

            var package = new Package(nameFirst, firstVersion.Object);
            var secondPackage = new object();

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() => package.Equals(secondPackage));
            StringAssert.Contains("The object must be IPackage", ex.Message);
        }

        [Test]
        public void ReturnTrue_WhenTheTwoPackagesAreEqual()
        {
            // Arrange 
            var nameFirst = "some name";
            var firstVersion = new Mock<IVersion>();

            var nameSecond = "some name";
            var secondVersion = new Mock<IVersion>();

            firstVersion.SetupGet(x => x.Major).Returns(1);
            firstVersion.SetupGet(x => x.Minor).Returns(1);
            firstVersion.SetupGet(x => x.Patch).Returns(1);
            firstVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            secondVersion.SetupGet(x => x.Major).Returns(1);
            secondVersion.SetupGet(x => x.Minor).Returns(1);
            secondVersion.SetupGet(x => x.Patch).Returns(1);
            secondVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var firstPackage = new Package(nameFirst, firstVersion.Object);
            var secondPackage = new Package(nameSecond, secondVersion.Object);

            // Act
            var comparisonResult = firstPackage.Equals(secondPackage);

            // Assert           
            Assert.IsTrue(comparisonResult);
        }

        [Test]
        public void ReturnFalse_WhenTheTwoPackagesAreNotEqual()
        {
            // Arrange 
            var nameFirst = "some name";
            var firstVersion = new Mock<IVersion>();

            var nameSecond = "some name";
            var secondVersion = new Mock<IVersion>();

            firstVersion.SetupGet(x => x.Major).Returns(1);
            firstVersion.SetupGet(x => x.Minor).Returns(1);
            firstVersion.SetupGet(x => x.Patch).Returns(1);
            firstVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            secondVersion.SetupGet(x => x.Major).Returns(2);
            secondVersion.SetupGet(x => x.Minor).Returns(2);
            secondVersion.SetupGet(x => x.Patch).Returns(2);
            secondVersion.SetupGet(x => x.VersionType).Returns(VersionType.beta);

            var firstPackage = new Package(nameFirst, firstVersion.Object);
            var secondPackage = new Package(nameSecond, secondVersion.Object);

            // Act
            var comparisonResult = firstPackage.Equals(secondPackage);

            // Assert           
            Assert.IsFalse(comparisonResult);
        }
    }
}
