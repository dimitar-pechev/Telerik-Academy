using System;
using System.Linq;
using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Engine.CommandTests
{
    [TestFixture]
    public class Parse_Should
    {
        [Test]
        [TestCase("CreateCategory ForMale")]
        [TestCase("ShowCategory ForMale")]
        public void ReturnNewCommand_WhenTheInputParamsAreInTheCorrectFormat(string input)
        {
            // Act 
            var command = Command.Parse(input);

            // Assert
            Assert.IsInstanceOf<Command>(command);
        }

        [Test]
        [TestCase("CreateCategory ForMale")]
        [TestCase("ShowCategory ForMale")]
        public void AssignCorrectlyCommandName_WhenTheInputParamsAreInTheCorrectFormat(string input)
        {
            // Arrange
            var expectedName = input.Split(' ')[0];
            
            // Act 
            var command = Command.Parse(input);

            // Assert
            Assert.AreEqual(expectedName, command.Name);
        }

        [Test]
        [TestCase("CreateCategory ForMale")]
        [TestCase("ShowCategory ForMale")]
        public void AssignCorrectlyCommandParameters_WhenTheInputParamsAreInTheCorrectFormat(string input)
        {
            // Arrange
            var expectedParams = input.Split(' ').Skip(1).ToList();

            // Act 
            var command = Command.Parse(input);

            // Assert
            Assert.AreEqual(expectedParams, command.Parameters);
        }


        [Test]
        public void ThrowNullRefException_WhenTheInputStringIsNull()
        {
            // Act & Assert
            Assert.Throws<NullReferenceException>(() => Command.Parse(null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheNameParamIsNullOrEmpty()
        {
            // Arrange
            var input = " params";

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
            StringAssert.Contains("Name", ex.Message);
        }

        [Test]
        public void ThrowArgumentNullException_WhenTheCommandParamIsNullOrEmpty()
        {
            // Arrange
            var input = "name ";

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
            StringAssert.Contains("List", ex.Message);
        }
    }
}
