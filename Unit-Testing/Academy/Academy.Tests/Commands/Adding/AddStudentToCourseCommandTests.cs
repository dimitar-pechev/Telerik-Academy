using System;
using Academy.Commands.Adding;
using Academy.Core.Contracts;
using Moq;
using NUnit.Framework;
using Academy.Tests.Commands.Mocks;
using System.Collections.Generic;
using Academy.Models.Contracts;

namespace Academy.Tests.Commands.Adding
{
    [TestFixture]
    public class AddStudentToCourseCommandTests
    {
        [Test]
        public void Constructor_ShouldThrow_WhenPassedFactoryProviderIsNull()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            IEngine engine = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factoryStub.Object, engine));
        }

        [Test]
        public void Constructor_ShouldThrow_WhenPassedEngineProviderIsNull()
        {
            //Arrange
            IAcademyFactory factory = null;
            var engineStub = new Mock<IEngine>(); ;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToCourseCommand(factory, engineStub.Object));
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignEngine_WhenInputParamsAreValid()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act 
            var command = new AddStudentToCourseCommandMock(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreSame(engineStub.Object, command.Engine);
        }

        [Test]
        public void Constructor_ShouldCorrectlyAssignFactory_WhenInputParamsAreValid()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineStub = new Mock<IEngine>();

            // Act 
            var command = new AddStudentToCourseCommandMock(factoryStub.Object, engineStub.Object);

            // Assert
            Assert.AreSame(factoryStub.Object, command.Factory);
        }

        [Test]
        public void Execute_ShouldThrow_WhenThePassedCourseFormIsInvalid()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0", "0", "invalid form" };

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentMock.Object };
            engineMock.SetupGet(x => x.Students).Returns(engineStudents);

            var courseMock = new Mock<ICourse>();
            var courses = new List<ICourse>() { courseMock.Object };

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Courses).Returns(courses);
            var seasons = new List<ISeason>() { seasonMock.Object };
            engineMock.SetupGet(x => x.Seasons).Returns(seasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_ShouldCorrectlyAddIntoTheOnlineCourse_WhenThePassedCourseFormIsInvalid()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0", "0", "online" };

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentMock.Object };
            engineMock.SetupGet(x => x.Students).Returns(engineStudents);

            var courseMock = new Mock<ICourse>();
            var onlineStudents = new List<IStudent>();
            courseMock.SetupGet(x => x.OnlineStudents).Returns(onlineStudents);
            var courses = new List<ICourse>() { courseMock.Object };

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Courses).Returns(courses);
            var seasons = new List<ISeason>() { seasonMock.Object };
            engineMock.SetupGet(x => x.Seasons).Returns(seasons);            

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            // Act
            command.Execute(parameters);

            // Assert 
            Assert.AreEqual(1, onlineStudents.Count);
        }

        [Test]
        public void Execute_ShouldCorrectlyAddIntoTheOnsiteCourse_WhenThePassedCourseFormIsInvalid()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0", "0", "onsite" };

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentMock.Object };
            engineMock.SetupGet(x => x.Students).Returns(engineStudents);

            var courseMock = new Mock<ICourse>();
            var onsiteStudents = new List<IStudent>();
            courseMock.SetupGet(x => x.OnsiteStudents).Returns(onsiteStudents);
            var courses = new List<ICourse>() { courseMock.Object };

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Courses).Returns(courses);
            var seasons = new List<ISeason>() { seasonMock.Object };
            engineMock.SetupGet(x => x.Seasons).Returns(seasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            // Act
            command.Execute(parameters);

            // Assert 
            Assert.AreEqual(1, onsiteStudents.Count);
        }

        [Test]
        public void Execute_ShouldReturnCorrectSuccessMessage_WhenThePassedCourseFormIsInvalid()
        {
            //Arrange
            var factoryStub = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0", "0", "onsite" };

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentMock.Object };
            engineMock.SetupGet(x => x.Students).Returns(engineStudents);

            var courseMock = new Mock<ICourse>();
            var onsiteStudents = new List<IStudent>();
            courseMock.SetupGet(x => x.OnsiteStudents).Returns(onsiteStudents);
            var courses = new List<ICourse>() { courseMock.Object };

            var seasonMock = new Mock<ISeason>();
            seasonMock.SetupGet(x => x.Courses).Returns(courses);
            var seasons = new List<ISeason>() { seasonMock.Object };
            engineMock.SetupGet(x => x.Seasons).Returns(seasons);

            var command = new AddStudentToCourseCommand(factoryStub.Object, engineMock.Object);

            // Act
            var message = command.Execute(parameters);

            // Assert 
            StringAssert.Contains("username", message);
            StringAssert.Contains("0", message);
        }
    }
}
