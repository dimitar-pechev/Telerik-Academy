using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Moq;
using NUnit.Framework;

namespace Academy.Tests.Models
{
    [TestFixture]
    public class SeasonTests
    {
        [Test]
        public void ListUsers_ShouldIterateOverListOfStudents_WhenTheListIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var studentMock = new Mock<IStudent>();
            studentMock.Setup(x => x.ToString());

            season.Students.Add(studentMock.Object);

            // Act
            var str = season.ListUsers();

            // Assert
            studentMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ShouldIterateOverListOfTrainers_WhenTheListIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var teacherMock = new Mock<ITrainer>();
            teacherMock.Setup(x => x.ToString());

            season.Trainers.Add(teacherMock.Object);

            // Act
            season.ListUsers();

            // Assert
            teacherMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListUsers_ShouldReturnCorrectMessage_WhenThereAreNoUsers()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var expectedValue = "There are no users in this season!";

            // Act and Assert
            Assert.AreEqual(expectedValue, season.ListUsers());
        }

        [Test]
        public void ListUsers_ShouldIterateOverListOfCourses_WhenTheListIsNotEmpty()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var courseMock = new Mock<ICourse>();
            courseMock.Setup(x => x.ToString());

            season.Courses.Add(courseMock.Object);

            // Act
            season.ListCourses();

            // Assert
            courseMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ListCourses_ShouldReturnCorrectMessage_WhenThereAreNoCourses()
        {
            // Arrange
            var season = new Season(2016, 2017, Initiative.SoftwareAcademy);
            var expectedValue = "There are no courses in this season!";

            // Act and Assert
            Assert.AreEqual(expectedValue, season.ListCourses());
        }
    }
}
