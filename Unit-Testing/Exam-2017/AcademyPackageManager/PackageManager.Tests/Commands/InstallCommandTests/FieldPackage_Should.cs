using Moq;
using NUnit.Framework;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;
using PackageManager.Tests.Commands.Mocks;
using System;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class FieldPackage_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenThePassedValueNull()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new ExtendedInstallCommand(installerMock.Object, null));
        }

        [Test]
        public void SetTheAppropriatePackageValue_WhenThePassedValueIsValid()
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
