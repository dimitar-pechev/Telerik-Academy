using System;
using Academy.Models;
using NUnit.Framework;
using System.Collections.Generic;
using Academy.Models.Contracts;
using Moq;

namespace Academy.Tests.Models
{
    [TestFixture]
    public class CourseTests
    {
        [Test]
        [TestCase("Balkan History", 5)]
        [TestCase("aaa", 1)]
        [TestCase("012345678901234567890123456789012345678912345", 7)]
        public void Constructor_ShouldNotThrow_WhenInputParamsAreValid(string name, int lecturesCount)
        {
            // Arrange
            var expectedName = name;
            var expecteedLexturesCount = lecturesCount;
            var expectedStartingDate = new DateTime(2017, 5, 11);
            var expectedEndDate = new DateTime(2017, 6, 11);

            // Act and Assert
            Assert.DoesNotThrow(() => new Course(expectedName, expecteedLexturesCount, expectedStartingDate, expectedEndDate));
        }

        [Test]
        [TestCase("Balkan History")]
        [TestCase("aaa")]
        [TestCase("012345678901234567890123456789012345678912345")]
        public void Constructor_ShouldCorrectlyAssignName_WhenInputParamsAreValid(string name)
        {
            // Arrange
            var expectedName = name;
            var expecteedLexturesCount = 5;
            var expectedStartingDate = new DateTime(2017, 5, 11);
            var expectedEndDate = new DateTime(2017, 6, 11);

            // Act
            var course = new Course(expectedName, expecteedLexturesCount, expectedStartingDate, expectedEndDate);

            // Assert
            Assert.AreEqual(expectedName, course.Name);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        public void Constructor_ShouldCorrectlyAssignLecturesCount_WhenInputParamsAreValid(int expecteedLexturesCount)
        {
            // Arrange
            var expectedName = "Balkan History";
            var expectedStartingDate = new DateTime(2017, 5, 11);
            var expectedEndDate = new DateTime(2017, 6, 11);

            // Act
            var course = new Course(expectedName, expecteedLexturesCount, expectedStartingDate, expectedEndDate);

            // Assert
            Assert.AreEqual(expecteedLexturesCount, course.LecturesPerWeek);
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignDates_WhenInputParamsAreValid()
        {
            // Arrange
            var expectedName = "Balkan History";
            var expecteedLexturesCount = 5;
            var expectedStartingDate = new DateTime(2017, 5, 11);
            var expectedEndDate = new DateTime(2017, 6, 11);

            // Act
            var course = new Course(expectedName, expecteedLexturesCount, expectedStartingDate, expectedEndDate);

            // Assert
            Assert.AreEqual(expectedStartingDate, course.StartingDate);
        }

        [Test]
        [TestCase("0123456789012345678901234567890123456789123456", 5)]
        [TestCase("aa", 5)]
        [TestCase("", 5)]
        [TestCase(null, 5)]
        [TestCase("Balkan History", 8)]
        [TestCase("Balkan History", 0)]
        [TestCase("Balkan History", -15)]
        public void Constructor_ShouldThrow_WhenCourseNameOrLecturesCountAreInvalid(string name, int lecturesCount)
        {
            // Arrange
            var expectedName = name;
            var expecteedLexturesCount = lecturesCount;
            var expectedStartingDate = new DateTime(2017, 5, 11);
            var expectedEndDate = new DateTime(2017, 6, 11);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new Course(expectedName, expecteedLexturesCount, expectedStartingDate, expectedEndDate));
        }

        [Test]
        public void Constructor_ShouldCorrectlyInitializeCollections_WhenInputParamsAreValid()
        {
            // Arrange and Act
            var course = new Course("Blakan History", 5, new DateTime(2017, 05, 11), new DateTime(2017, 06, 11));

            // Assert
            Assert.IsNotNull(course.OnlineStudents);
            Assert.IsNotNull(course.OnsiteStudents);
            Assert.IsNotNull(course.Lectures);

            Assert.AreEqual("System.Collections.Generic.List`1[Academy.Models.Contracts.IStudent]", course.OnlineStudents.GetType().ToString());
            Assert.AreEqual("System.Collections.Generic.List`1[Academy.Models.Contracts.IStudent]", course.OnsiteStudents.GetType().ToString());
            Assert.AreEqual("System.Collections.Generic.List`1[Academy.Models.Contracts.ILecture]", course.Lectures.GetType().ToString());
        }

        [Test]
        public void ToString_ShouldIterateOverCollections_WhenLecturesListIsEmpty()
        {
            // Arrange
            var course = new Course("Blakan History", 5, new DateTime(2017, 05, 11), new DateTime(2017, 06, 11));

            var lectureMock = new Mock<ILecture>();
            lectureMock.Setup(x => x.ToString());            
            course.Lectures.Add(lectureMock.Object);

            //Act
            course.ToString();

            // Act & Assert
            lectureMock.Verify(x => x.ToString(), Times.Once);
        }

        [Test]
        public void ToString_ShouldReturnCorrectMessage_WhenLecturesListIsEmpty()
        {
            // Arrange
            var course = new Course("Balkan History", 5, new DateTime(2017, 05, 11), new DateTime(2017, 06, 11));

            // Act
            var message = course.ToString();

            // Assert 
            StringAssert.Contains("  * There are no lectures in this course!", message);
        }
    }
}
