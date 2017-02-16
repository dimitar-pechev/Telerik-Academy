using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System;
using System.Collections.Generic;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class Delete_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedPackageObjIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => repo.Delete(null));
            StringAssert.Contains("Package cannot be null", ex.Message);
        }

        [Test]
        public void RemovePackageFromList_WhenPassedPackageExistInThePackagesList()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("nqma me");
            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            packages.Add(packageMock.Object);
            var countBeforeDelete = packages.Count;

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act 
            repo.Delete(packageMock.Object);

            // Assert
            Assert.AreEqual(1, countBeforeDelete);
            Assert.AreEqual(0, packages.Count);
        }

        [Test]
        public void ThrowArgumentNullExcseption_WhenPassedPackageDoesNotExistInThePackagesList()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("nqma me");

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => repo.Delete(packageMock.Object));
            StringAssert.Contains("Package cannot be null", ex.Message);
            loggerMock.Verify(x => x.Log($"{packageMock.Object.Name}: The package does not exist!"), Times.Once);
        }

        [Test]
        public void NotRemovePackage_WhenPassedPackageIsADependencyToSomeOtherPackage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();
            var packageWithDependencyMock = new Mock<IPackage>();

            packageWithDependencyMock.Setup(x => x.Dependencies).Returns(new List<IPackage>() { packageMock.Object });
            packageWithDependencyMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);

            packageMock.Setup(x => x.Name).Returns("nqma me");
            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>() { packageWithDependencyMock.Object });

            packages.Add(packageMock.Object);
            var countBeforeDelete = packages.Count;

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act & Assert
            // Added the exception
            Assert.Throws<InvalidOperationException>(() => repo.Delete(packageMock.Object));
            loggerMock.Verify(x => x.Log($"{packageMock.Object.Name}: The package is a dependency and could not be removed!"), Times.Once);
        }

        [Test]
        public void ReturnTheRemovedPackage_WhenDeleteMethodWasSuccessful()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Name).Returns("nqma me");
            packageMock.Setup(x => x.Equals(It.IsAny<IPackage>())).Returns(true);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>());

            packages.Add(packageMock.Object);
            var countBeforeDelete = packages.Count;

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act 
            var deletedPackage = repo.Delete(packageMock.Object);

            // Assert
            Assert.AreSame(packageMock.Object, deletedPackage);
        }
    }
}
