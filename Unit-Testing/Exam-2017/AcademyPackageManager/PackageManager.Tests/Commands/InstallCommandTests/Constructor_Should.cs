using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Mocks;
using System;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenTheInstallerObjIsNull()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ExtendedInstallCommand(null, packageMock.Object));
        }

        [Test]
        public void ThrowArgumentNullException_WhenThePackageObjIsNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ExtendedInstallCommand(installerMock.Object, null));
        }

        [Test]
        public void CorrectlyInstantiateCommand_WhenTheInputParamsAreValid()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var extendedInstallCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.IsInstanceOf<ExtendedInstallCommand>(extendedInstallCommand);
        }

        [Test]
        public void SetTheAppropriateInstallerValue_WhenTheInputParamsAreValid()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var extendedInstallCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(installerMock.Object, extendedInstallCommand.Installer);
        }

        [Test]
        public void SetTheAppropriatePackageValue_WhenTheInputParamsAreValid()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();

            // Act
            var extendedInstallCommand = new ExtendedInstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            Assert.AreSame(packageMock.Object, extendedInstallCommand.Package);
        }
    }
}
