using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Mocks;
using System;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class FieldInstaller_Should
    {
        [Test]
        public void SetTheAppropriateInstallerValue_WhenTheInputValueIsValid()
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
        public void ThrowArgumentNullException_WhenThePassedValueIsNull()
        {
            // Arrange
            var packageMock = new Mock<IPackage>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ExtendedInstallCommand(null, packageMock.Object));
        }
    }
}
