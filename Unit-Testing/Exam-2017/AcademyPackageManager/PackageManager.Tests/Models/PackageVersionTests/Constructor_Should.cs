using NUnit.Framework;
using PackageManager.Enums;

namespace PackageManager.Tests.Models.PackageVersion
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetTheAppropriateMajorValue_WhenTheInputParametersAreValid()
        {
            // Arrange
            var major = 1;
            var minor = 1;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(major, packageVersion.Major);
        }


        [Test]
        public void SetTheAppropriateMinorValue_WhenTheInputParametersAreValid()
        {
            // Arrange
            var major = 1;
            var minor = 1;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(minor, packageVersion.Minor);
        }


        [Test]
        public void SetTheAppropriatePatchValue_WhenTheInputParametersAreValid()
        {
            // Arrange
            var major = 1;
            var minor = 1;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(patch, packageVersion.Patch);
        }


        [Test]
        public void SetTheAppropriateMajorVersionType_WhenTheInputParametersAreValid()
        {
            // Arrange
            var major = 1;
            var minor = 1;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(versionType, packageVersion.VersionType);
        }
    }
}
