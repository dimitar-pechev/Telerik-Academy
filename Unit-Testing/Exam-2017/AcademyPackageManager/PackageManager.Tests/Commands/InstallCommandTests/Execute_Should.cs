using Moq;
using NUnit.Framework;
using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
    [TestFixture]
    public class Execute_Should
    {
        [Test]
        public void CallThePerformOperationFromTheInstaller()
        {
            // Arrange
            var installerMock = new Mock<IInstaller<IPackage>>();
            var packageMock = new Mock<IPackage>();
            var installCommand = new InstallCommand(installerMock.Object, packageMock.Object);

            // Act
            installCommand.Execute();

            // Assert
            installerMock.Verify(x => x.PerformOperation(packageMock.Object), Times.Once);
        }
    }
}
