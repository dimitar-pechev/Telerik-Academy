using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using Academy.Core.Contracts;
using Academy.Commands.Adding;
using System.Collections.Generic;
using Academy.Models.Contracts;

namespace Academy.Tests.Commands.Adding
{
    [TestFixture]
    public class AddStudentToSeasonCommandTests
    {
        [Test]
        public void Contructor_ShouldThrow_WhenPassedFactoryProviderIsNull()
        {
            // Arrange
            var academyFactoryStub = new Mock<IAcademyFactory>();
            IEngine engine = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(academyFactoryStub.Object, engine));
        }

        [Test]
        public void Contructor_ShouldThrow_WhenPassedEngineProviderIsNull()
        {
            // Arrange
            IAcademyFactory academyFactoryStub = null;
            var engine = new Mock<IEngine>();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AddStudentToSeasonCommand(academyFactoryStub, engine.Object));
        }

        [Test]
        public void Contructor_ShouldAssignCorrectValues_WhenPassedDataIsValid()
        {
            // Arrange
            var factory = new Mock<IAcademyFactory>();
            var engine = new Mock<IEngine>();

            // Act
            var command = new AddStudentsToSeasonCommandMock(factory.Object, engine.Object);

            // Assert
            Assert.AreEqual(engine.Object, command.Engine);
            Assert.AreEqual(factory.Object, command.Factory);
        }

        [Test]
        public void Execute_ShouldThrow_WhenThePassedStudentIsAlreadyAPartOfThatSeason()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0" };
            var seasonMock = new Mock<ISeason>();
            var studentMock = new Mock<IStudent>();

            studentMock.SetupGet(x => x.Username).Returns("username");
            var seasonStudents = new List<IStudent>() { studentMock.Object };
           
            seasonMock.SetupGet(x => x.Students).Returns(seasonStudents);
            engineMock.SetupGet(x => x.Students).Returns(seasonStudents);

            engineMock.Setup(x => x.Seasons[0]).Returns(seasonMock.Object);

            var command = new AddStudentsToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => command.Execute(parameters));
        }

        [Test]
        public void Execute_ShouldCorrectlyAddTheFoundStudentIntoTheSeason_WhenThePassedStudentIsNotYetPresent()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0" };
            var seasonMock = new Mock<ISeason>();

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentMock.Object };

            var studentMockSeason = new Mock<IStudent>();
            studentMockSeason.SetupGet(x => x.Username).Returns("not username");
            var seasonStudents = new List<IStudent>() { studentMockSeason.Object };

            engineMock.SetupGet(x => x.Students).Returns(engineStudents);
            seasonMock.SetupGet(x => x.Students).Returns(seasonStudents);

            engineMock.Setup(x => x.Seasons[0]).Returns(seasonMock.Object);

            var command = new AddStudentsToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            // Act 
            command.Execute(parameters);

            // Assert
            Assert.AreEqual(2, seasonMock.Object.Students.Count);
        }

        [Test]
        public void Execute_ShouldReturnCorrectMessageOnAddingStudent_WhenThePassedStudentIsNotYetPresent()
        {
            var factoryMock = new Mock<IAcademyFactory>();
            var engineMock = new Mock<IEngine>();
            var parameters = new List<string>() { "username", "0" };
            var seasonMock = new Mock<ISeason>();

            var studentMock = new Mock<IStudent>();
            studentMock.SetupGet(x => x.Username).Returns("username");
            var engineStudents = new List<IStudent>() { studentMock.Object };

            var studentMockSeason = new Mock<IStudent>();
            studentMockSeason.SetupGet(x => x.Username).Returns("not username");
            var seasonStudents = new List<IStudent>() { studentMockSeason.Object };

            engineMock.SetupGet(x => x.Students).Returns(engineStudents);
            seasonMock.SetupGet(x => x.Students).Returns(seasonStudents);

            engineMock.Setup(x => x.Seasons[0]).Returns(seasonMock.Object);

            var command = new AddStudentsToSeasonCommandMock(factoryMock.Object, engineMock.Object);

            // Act 
            var message = command.Execute(parameters);

            // Assert
            Assert.AreEqual("Student username was added to Season 0.", message);
        }
    }
}
