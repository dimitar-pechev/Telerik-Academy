using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Tests.Models.PackageTest
{
    [TestFixture]
    public class CompareTo_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenObjOtherIsNull()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            var package = new Package(name, version.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => package.CompareTo(null));
        }

        [Test]
        public void ThrowArgumentException_WhenObjOthersNameIsDiffernet()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            var nameSecond = "some other name";
            var secondVersion = new Mock<IVersion>();
            var package = new Package(name, version.Object);
            var secondPackage = new Package(nameSecond, secondVersion.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => package.CompareTo(secondPackage));
        }

        [Test]
        public void ShouldNotThrow_WhenObjOthersIsValid()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            var nameSecond = "some name";
            var secondVersion = new Mock<IVersion>();
            var package = new Package(name, version.Object);
            var secondPackage = new Package(nameSecond, secondVersion.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => package.CompareTo(secondPackage));
        }

        [Test]
        public void CorrectlyIndicateWhichTheLowerVerion_WhenObjOtherIsValid()
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
            var comparisonResult = firstPackage.CompareTo(secondPackage);
            // Assert
            // -1 is expected as firstPackage is a lower version
            Assert.AreEqual(-1, comparisonResult);
        }

        [Test]
        public void CorrectlyIndicateWhichTheHigherVerion_WhenObjOtherIsValid()
        {
            // Arrange 
            var nameFirst = "some name";
            var firstVersion = new Mock<IVersion>();

            var nameSecond = "some name";
            var secondVersion = new Mock<IVersion>();

            firstVersion.SetupGet(x => x.Major).Returns(2);
            firstVersion.SetupGet(x => x.Minor).Returns(2);
            firstVersion.SetupGet(x => x.Patch).Returns(2);
            firstVersion.SetupGet(x => x.VersionType).Returns(VersionType.final);

            secondVersion.SetupGet(x => x.Major).Returns(1);
            secondVersion.SetupGet(x => x.Minor).Returns(2);
            secondVersion.SetupGet(x => x.Patch).Returns(2);
            secondVersion.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var firstPackage = new Package(nameFirst, firstVersion.Object);
            var secondPackage = new Package(nameSecond, secondVersion.Object);

            // Act
            var comparisonResult = firstPackage.CompareTo(secondPackage);
            // Assert
            // 1 is expected as firstPackage is a higher version
            Assert.AreEqual(1, comparisonResult);
        }

        [Test]
        public void CorrectlyIndicateThatTheTwoPackagesAreTheSameVersion_WhenObjOtherIsValid()
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
            var comparisonResult = firstPackage.CompareTo(secondPackage);
            // Assert
            // 0 is expected as the two packages are the same version
            Assert.AreEqual(0, comparisonResult);
        }
    }
}
