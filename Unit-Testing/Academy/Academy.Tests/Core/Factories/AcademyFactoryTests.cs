using Academy.Core.Factories;
using NUnit.Framework;
using System;

namespace Academy.Tests.Core.Factories
{
    [TestFixture]
    public class AcademyFactoryTests
    {
        [Test]
        [TestCase("video", "Academy.Models.Utils.LectureResources.VideoResource")]
        [TestCase("presentation", "Academy.Models.Utils.LectureResources.PresentationResource")]
        [TestCase("demo", "Academy.Models.Utils.LectureResources.DemoResource")]
        [TestCase("homework", "Academy.Models.Utils.LectureResources.HomeworkResource")]
        public void CreateLectureResource_ShouldThrow_WhenInvalidInputIsPassed(string resType, string expectedType)
        {
            // Arrange
            var academyFacotry = AcademyFactory.Instance;
            var type = resType;
            var name = "VidPresDemHW";
            var url = "https://.../404.baby";

            // Act
            var resource = academyFacotry.CreateLectureResource(type, name, url);

            // Assert
            Assert.AreEqual(expectedType, resource.GetType().ToString());
        }

        [Test]
        [TestCase("pey syrce... jegata pak doide")]
        [TestCase("presentattion")]
        [TestCase("demoo")]
        public void CreateLectureResource_ShouldThrow_WhenInvalidInputIsPassed(string resType)
        {
            // Arrange
            var academyFacotry = AcademyFactory.Instance;
            var type = resType;
            var name = "VidPresDemHW";
            var url = "https://.../404.baby";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => academyFacotry.CreateLectureResource(type, name, url));
        }
    }
}
