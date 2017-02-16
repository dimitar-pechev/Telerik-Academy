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
    public class Add_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenPassedValueIsNull()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var repo = new PackageRepository(loggerMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => repo.Add(null));
        }

        [Test]
        public void AddNewPackage_WhenPassedPackageObjDoesExistInTheHashSet()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();


            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act
            repo.Add(packageMock.Object);

            // Assert
            Assert.IsTrue(packages.Contains(packageMock.Object));
            Assert.AreEqual(1, packages.Count);
        }

        [Test]
        public void NotAddPackage_WhenPassedPackageObjWithTheSameVersionExists()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var firstPackageMock = new Mock<IPackage>();
            var secondPackageMock = new Mock<IPackage>();

            secondPackageMock.Setup(x => x.CompareTo(firstPackageMock.Object)).Returns(0);

            firstPackageMock.Setup(x => x.Name).Returns("golqm paket be");
            packages.Add(firstPackageMock.Object);

            secondPackageMock.Setup(x => x.Name).Returns("golqm paket be");

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act
            repo.Add(secondPackageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log($"{secondPackageMock.Object.Name}: Package with the same version is already installed!"),
                Times.Once);
        }

        [Test]
        public void UpdatePackage_WhenPassedPackageObjWithHigherVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var firstPackageMock = new Mock<IPackage>();
            var secondPackageMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            secondPackageMock.Setup(x => x.CompareTo(firstPackageMock.Object)).Returns(1);

            firstPackageMock.Setup(x => x.Name).Returns("golqm paket be");
            packages.Add(firstPackageMock.Object);

            secondPackageMock.Setup(x => x.Name).Returns("golqm paket be");
            secondPackageMock.Setup(x => x.Version).Returns(versionMock.Object);

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act
            repo.Add(secondPackageMock.Object);

            // Assert
            firstPackageMock.VerifySet(x => x.Version = versionMock.Object, Times.Once);
        }

        [Test]
        public void NotAddPackage_WhenPassedPackageObjIsWithLowerVersion()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var firstPackageMock = new Mock<IPackage>();
            var secondPackageMock = new Mock<IPackage>();
            var versionMock = new Mock<IVersion>();

            secondPackageMock.Setup(x => x.CompareTo(firstPackageMock.Object)).Returns(-1);

            firstPackageMock.Setup(x => x.Name).Returns("golqm paket be");
            packages.Add(firstPackageMock.Object);

            secondPackageMock.Setup(x => x.Name).Returns("golqm paket be");
            secondPackageMock.Setup(x => x.Version).Returns(versionMock.Object);

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act
            repo.Add(secondPackageMock.Object);

            // Assert
            loggerMock.Verify(x => x.Log($"{secondPackageMock.Object.Name}: There is a package with newer version!"), 
                Times.Once);
        }
    }
}
