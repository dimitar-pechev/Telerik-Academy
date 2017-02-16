using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class InstallerOperationPorperty_Should
    {
        [Test]
        public void BeCorrectlyAssignedFromTheConstructor_WhenTheInputParamsAreValid()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
                        
            // Act
            var extendedInstallCommand = new InstallCommand(installerMock.Object, packageMock.Object);

            // Assert
            installerMock.VerifySet(x => x.Operation = InstallerOperation.Install, Times.Once);
        }
    }
}
