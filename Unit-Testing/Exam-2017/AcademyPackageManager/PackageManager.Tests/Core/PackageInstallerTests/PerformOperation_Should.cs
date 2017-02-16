using Moq;
using NUnit.Framework;
using PackageManager.Core;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PackageManager.Tests.Core.PackageInstallerTests
{
    [TestFixture]
    public class PerformOperation_Should
    {
        [Test]
        public void CallProjectDownloadTwice_WhenThereAreNoDependencies()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Dependencies.Count).Returns(0);
            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            downloaderMock.Setup(x => x.Download(It.IsAny<string>()));

            // Act
            var packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(2));
        }
       
            [Test]
        public void CallProjectRemoveOnce_WhenThereAreNoDependencies()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();

            packageMock.Setup(x => x.Dependencies.Count).Returns(0);
            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            downloaderMock.Setup(x => x.Remove(It.IsAny<string>()));

            // Act
            var packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void CallProjectDownloadMultipleTimes_WhenThereAreDependencies()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            var dependencyPackageMock = new Mock<IPackage>();

            dependencyPackageMock.Setup(x => x.Dependencies.Count).Returns(0);

            packageMock.Setup(x => x.Dependencies.Count).Returns(1);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>() { dependencyPackageMock.Object });

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            downloaderMock.Setup(x => x.Download(It.IsAny<string>()));

            // Act
            var packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            // 4 times as there is only one dependency
            downloaderMock.Verify(x => x.Download(It.IsAny<string>()), Times.Exactly(4));
        }

        [Test]
        public void CallProjectRemoveMultipleTimes_WhenThereAreDependencies()
        {
            // Arrange
            var downloaderMock = new Mock<IDownloader>();
            var projectMock = new Mock<IProject>();
            var packageMock = new Mock<IPackage>();
            var dependencyPackageMock = new Mock<IPackage>();

            dependencyPackageMock.Setup(x => x.Dependencies.Count).Returns(0);

            packageMock.Setup(x => x.Dependencies.Count).Returns(1);
            packageMock.Setup(x => x.Dependencies).Returns(new List<IPackage>() { dependencyPackageMock.Object });

            projectMock.Setup(x => x.PackageRepository.GetAll()).Returns(new List<IPackage>() { packageMock.Object });
            downloaderMock.Setup(x => x.Remove(It.IsAny<string>()));

            // Act
            var packageInstaller = new PackageInstaller(downloaderMock.Object, projectMock.Object);

            // Assert
            // 4 times as there is only one dependency
            downloaderMock.Verify(x => x.Remove(It.IsAny<string>()), Times.Exactly(2));
        }
    }
}
