using System;
using NUnit.Framework;
using IntergalacticTravel.Exceptions;

namespace IntergalacticTravel.Tests.UnitsFactoryTests
{
    [TestFixture]
    public class GetUnit_Should
    {
        [Test]
        public void ReturnANewProcyonUnit_WhenAValidCommandIsPassed()
        {
            // Arrange
            var factory = new UnitsFactory();

            // Act
            var procyon = factory.GetUnit("create unit Procyon Gosho 1");

            // Assert
            Assert.IsInstanceOf<Procyon>(procyon);
        }

        [Test]
        public void ReturnANewLuytenUnit_WhenAValidCommandIsPassed()
        {
            // Arrange
            var factory = new UnitsFactory();

            // Act
            var luyten = factory.GetUnit("create unit Luyten Pesho 2");

            // Assert
            Assert.IsInstanceOf<Luyten>(luyten);
        }

        [Test]
        public void ReturnANewLacailleUnit_WhenAValidCommandIsPassed()
        {
            // Arrange
            var factory = new UnitsFactory();

            // Act
            var lacaille = factory.GetUnit("create unit Lacaille Tosho 3");

            // Assert
            Assert.IsInstanceOf<Lacaille>(lacaille);
        }

        [Test]
        [TestCase("aksdlasldas")]
        [TestCase("create unit Lacaile Tosho 3")]
        [TestCase("create unit Lacaile Tosho -10")]
        [TestCase("create unit Lacaille Tosho")]
        [TestCase("create Lacaille Tosho 10")]
        public void ThrowInvalidUnitCreationCommandException_WhenThePassedCommandIsInvalid(string command)
        {
            // Arrange 
            var factory = new UnitsFactory();

            // Act & Assert
            Assert.Throws<InvalidUnitCreationCommandException>(() => factory.GetUnit(command));
        }
    }
}
