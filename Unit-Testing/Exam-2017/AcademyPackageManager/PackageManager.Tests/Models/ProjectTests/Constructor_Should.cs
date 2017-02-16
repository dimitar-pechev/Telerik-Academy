using Moq;
using NUnit.Framework;
using PackageManager.Info;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using PackageManager.Repositories;
using PackageManager.Repositories.Contracts;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void AssignNameValueCorrectly_WhenInputParamsAreValid()
        {
            // Arrange
            var name = "such name";
            var location = "much location";

            // Act
            var project = new Project(name, location, null);

            // Assert
            Assert.AreEqual(name, project.Name);
        }

        [Test]
        public void AssignLocationValueCorrectly_WhenInputParamsAreValid()
        {
            // Arrange
            var name = "such name";
            var location = "much location";

            // Act
            var project = new Project(name, location, null);

            // Assert
            Assert.AreEqual(location, project.Location);
        }

        [Test]
        public void AssignLocationValueCorrectly_WhenInputParamsAreValidAndPassedPackagesObjIsNull()
        {
            // Arrange
            var name = "such name";
            var location = "much location";

            // Act
            var project = new Project(name, location, null);

            // Assert
            Assert.IsInstanceOf<PackageRepository>(project.PackageRepository);
        }

        [Test]
        public void AssignLocationValueCorrectly_WhenInputParamsAreValidAndPassedPackagesObjIsNotNull()
        {
            // Arrange
            var name = "such name";
            var location = "much location";
            var packageRepo = new Mock<IRepository<IPackage>>();

            // Act
            var project = new Project(name, location, packageRepo.Object);

            // Assert
            Assert.AreEqual(packageRepo.Object, project.PackageRepository);
        }
    }
}
