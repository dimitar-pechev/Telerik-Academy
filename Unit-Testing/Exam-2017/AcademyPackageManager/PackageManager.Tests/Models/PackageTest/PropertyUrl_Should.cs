using Moq;
using NUnit.Framework;
using PackageManager.Enums;
using PackageManager.Models;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Models.PackageTest
{
    [TestFixture]
    public class PropertyUrl_Should
    {
        [Test]
        [TestCase(1, 0, 10, VersionType.alpha)]
        [TestCase(10, 220, 0, VersionType.beta)]
        [TestCase(42, 42, 42, VersionType.final)]
        public void BeSetCorrectly_WhenPassedParamsAreValid(int major, int minor, int patch, VersionType type)
        {
            // Arrange 
            var name = "some name";
            var version = new Mock<IVersion>();
            version.SetupGet(x => x.Major).Returns(major);
            version.SetupGet(x => x.Minor).Returns(minor);
            version.SetupGet(x => x.Patch).Returns(patch);
            version.SetupGet(x => x.VersionType).Returns(type);

            var expectedValue = string.Format("{0}.{1}.{2}-{3}", version.Object.Major, version.Object.Minor, version.Object.Patch, version.Object.VersionType);

            // Act 
            var package = new Package(name, version.Object);

            // Assert
            Assert.AreEqual(expectedValue, package.Url);
        }
    }
}
