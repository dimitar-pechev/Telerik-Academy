using NUnit.Framework;
using PackageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageManager.Tests.Models.ProjectTests
{
    [TestFixture]
    public class PropertyName_Should
    {
        [Test]
        [TestCase("short random")]
        [TestCase("loooooooooooooooonger random")]
        public void SetNameCorrectly_WhenPassedValueIsValid(string name)
        {
            // Arrange
            var location = "much location";

            // Act
            var project = new Project(name, location, null);

            // Assert
            Assert.AreEqual(name, project.Name);
        }

        public void ThrowArgumentNullException_WhenPassedValueIsNull()
        {
            // Arrange
            string name = null;
            var location = "much location";
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Project(name, location, null));
        }
    }
}
