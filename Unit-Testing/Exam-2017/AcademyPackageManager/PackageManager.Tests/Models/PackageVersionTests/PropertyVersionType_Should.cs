using NUnit.Framework;
using PackageManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.PackageVersion
{
    [TestFixture]
    public class PropertyVersionType_Should
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void SetValueCorrectly_WhenPassedValueIsValid(int versionType)
        {
            // Arrange            
            var major = 1;
            var patch = 1;
            var minor = 1;

            // Act
            var packageVersion = new PackageManager.Models.PackageVersion(major, minor, patch, (VersionType)versionType);

            // Assert
            Assert.AreEqual(versionType, (int)packageVersion.VersionType);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(4)]
        public void Throw_WhenPassedValueIsValid(int versionType)
        {
            // Arrange            
            var major = 1;
            var patch = 1;
            var minor = 1;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new PackageManager.Models.PackageVersion(major, minor, patch, (VersionType)versionType));
        }
    }
}
