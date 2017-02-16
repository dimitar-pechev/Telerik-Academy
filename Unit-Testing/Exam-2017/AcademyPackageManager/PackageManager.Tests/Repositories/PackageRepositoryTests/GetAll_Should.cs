using Moq;
using NUnit.Framework;
using PackageManager.Info.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PackageManager.Tests.Repositories.PackageRepositoryTests
{
    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void ReturnEmptyCollection_WhenNoPackagesWerePresent()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();

            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act 
            var packagesInRepo = repo.GetAll().ToArray();

            // Assert
            Assert.AreEqual(0, packagesInRepo.Length);
        }

        [Test]
        public void ReturnACollectionOfTwoObjects_WhenThereTwoObjInIt()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>();
            var packages = new HashSet<IPackage>();
            var packageMock = new Mock<IPackage>();
            var secondPackageMock = new Mock<IPackage>();

            packages.Add(packageMock.Object);
            packages.Add(secondPackageMock.Object);
            var repo = new PackageRepository(loggerMock.Object, packages);

            // Act 
            var packagesInRepo = repo.GetAll().ToArray();

            // Assert
            Assert.AreEqual(2, packagesInRepo.Length);
        }
    }
}
