using System;
using NUnit.Framework;
using PackageManager.Enums;

namespace PackageManager.Tests.Models.PackageVersion
{
    [TestFixture]
    public class PropertyMinor_Should
    {
        [Test]
        [TestCase(1)]
        [TestCase(50)]
        public void SetValueCorrectly_WhenPassedValueIsValid(int minor)
        {
            // Arrange            
            var major = 1;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, versionType);

            // Assert
            Assert.AreEqual(minor, packageVersion.Minor);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-50)]
        public void Throw_WhenPassedValueIsValid(int minor)
        {
            // Arrange            
            var major = 1;
            var patch = 1;
            var versionType = VersionType.alpha;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageManager.Models.PackageVersion(major, minor, patch, versionType));
        }
    }
}
