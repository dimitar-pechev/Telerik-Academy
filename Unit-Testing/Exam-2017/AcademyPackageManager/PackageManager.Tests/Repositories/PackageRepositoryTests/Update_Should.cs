using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class Update_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedObjectIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => repo.Update(null));
            StringAssert.Contains("The package cannot be null", ex.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPackageIsNotFoundInTheRepoCollection()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("nqma me");

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.Update(packageMock.Object));
            loggerMock.Verify(x => x.Log($"{packageMock.Object.Name}: The package does not exist!"), Times.Once);
        }

        [Test]
        public void SuccessfullyCompleteOperation_WhenAPackageWithALowerVersionIsFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            packageMock.Setup(x => x.Version).Returns(versionMock.Object);
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(1);
            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageMock.Setup(x => x.Name).Returns("golqm paket be");
            packages.Add(packageMock.Object);            

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act 
            repo.Update(packageMock.Object);

            // Assert
            packageMock.VerifySet(x => x.Version = versionMock.Object, Times.Once);
        }

        [Test]
        public void NotUpdate_WhenAPackageWithAHigherVersionIsFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            packageMock.Setup(x => x.Version).Returns(versionMock.Object);
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(-1);
            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageMock.Setup(x => x.Name).Returns("golqm paket be");
            packages.Add(packageMock.Object);

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => repo.Update(packageMock.Object));
            loggerMock.Verify(x => x.Log($"{packageMock.Object.Name}: The package has higher version than you are trying to install!"), Times.Once);
        }

        [Test]
        public void NotUpdate_WhenAPackageWithTheSameVersionIsFound()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            packageMock.Setup(x => x.Version).Returns(versionMock.Object);
            packageMock.Setup(x => x.CompareTo(It.IsAny<IPackage>())).Returns(0);
            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageMock.Setup(x => x.Name).Returns("golqm paket be");
            packages.Add(packageMock.Object);

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act
            repo.Update(packageMock.Object);

            // Assert            
            loggerMock.Verify(x => x.Log($"{packageMock.Object.Name}: Package with the same version is already installed!"), Times.Once);
        }
    }
}
