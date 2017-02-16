using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;
using System.Collections.Generic;

namespace PackageManager.Tests.Models.PackageTest
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void CorrectlyAssignNameValue_WhenPassedParamsAreValid()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(name, package.Name);
        }

        [Test]
        public void CorrectlyAssignVersionValue_WhenPassedParamsAreValid()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(version.Object, package.Version);
        }

        [Test]
        public void CorrectlyAssignDependenciesValue_WhenPassedParamsAreValidAndNoDependenciesObjIsPassed()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            var expectedDependencyValue = new HashSet<IPackage>();

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(expectedDependencyValue, package.Dependencies);
        }

        [Test]
        public void CorrectlyAssignDependenciesValue_WhenPassedParamsAreValidAndDependenciesObjIsPassed()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            var expectedDependencyValue = new HashSet<IPackage>();

            // Act 
            var package = new Package(name, version.Object, expectedDependencyValue);

            // Assert
            Assert.AreSame(expectedDependencyValue, package.Dependencies);
        }

        [Test]
        public void CorrectlyAssignUrlalue_WhenPassedParamsAreValid()
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            version.SetupGet(x => x.Major).Returns(1);
            version.SetupGet(x => x.Minor).Returns(0);
            version.SetupGet(x => x.Patch).Returns(10);
            version.SetupGet(x => x.VersionType).Returns(VersionType.alpha);

            var expectedValue = string.Format("{0}.{1}.{2}-{3}", version.Object.Major, version.Object.Minor, version.Object.Patch, version.Object.VersionType);

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(expectedValue, package.Url);
        }
    }
}
