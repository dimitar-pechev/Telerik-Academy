using NUnit.Framework;
using PackageManager.Models;
using System;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class PropertyLocation_Should
    {
        [Test]
        [TestCase("short random")]
        [TestCase("loooooooooooooooonger random")]
        public void SetNameCorrectly_WhenPassedValueIsValid(string location)
        {
            // Arrange
            var name = "much name";

            // Act
            var project = new Project(name, location, null);

            // Assert
            Assert.AreEqual(name, project.Name);
        }

        public void ThrowArgumentNullException_WhenPassedValueIsNull()
        {
            // Arrange
            string location = null;
            var name = "much name";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, location, null));
        }
    }
}
