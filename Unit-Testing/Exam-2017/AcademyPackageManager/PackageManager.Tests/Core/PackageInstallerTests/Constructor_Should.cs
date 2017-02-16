using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Core.Mocks;
using System.Collections.Generic;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void AssignDawnloaderValueCorrectly_WhenInputParamsAreValid()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            // Act
            var packageInstaller = new ExtendedPackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            Assert.AreSame(downloaderMock.Object, packageInstaller.Downloader);
        }

        [Test]
        public void AssignProjectValueCorrectly_WhenInputParamsAreValid()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            // Act
            var packageInstaller = new ExtendedPackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            Assert.AreSame(projectMock.Object, packageInstaller.Project);
        }

        [Test]
        public void ShouldCallRestorePackagesMehtod_WhenInputParamsAreValid()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>());

            // Act
            var packageInstaller = new ExtendedPackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            // The project.PackageRepository.GetAll() method is called from the inside of the RestorePackages() Mehtod
            projectMock.Verify(x => x.PackageRepository.GetAll(), Times.Once);
        }
    }
}
