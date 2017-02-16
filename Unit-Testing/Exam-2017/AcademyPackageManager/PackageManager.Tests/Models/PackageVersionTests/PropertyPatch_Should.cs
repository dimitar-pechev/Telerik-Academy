using NUnit.Framework;
using PackageManager.Enums;
using System;

namespace PackageManager.Tests.Models.PackageVersion
{
    [TestFixture]
    public class PropertyPatch_Should
    {
        [Test]
        [TestCase(1)]
        [TestCase(50)]
        public void SetValueCorrectly_WhenPassedValueIsValid(int patch)
        {
            // Arrange            
            var major = 1;
            var minor = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(patch, packageVersion.Patch);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        public void Throw_WhenPassedValueIsValid(int patch)
        {
            // Arrange            
            var major = 1;
            var minor = 1;
            var versionType = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageManager.Models.PackageVersion(major, minor, patch, versionType));
        }
    }
}
