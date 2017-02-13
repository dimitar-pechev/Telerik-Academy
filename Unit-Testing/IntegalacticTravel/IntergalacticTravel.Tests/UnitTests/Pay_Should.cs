using System;
using Moq;
using NUnit.Framework;
using IntergalacticTravel.Contracts;

namespace IntergalacticTravel.Tests.UnitTests
{
    [TestFixture]
    public class Pay_Should
    {
        [Test]
        public void ThrowNullReferenceException_WhenThePassedObjectIsNull()
        {
            // Arrange
            var unit = new Unit(1, "birenoto chudovishte");

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void DecreaseTheOwnersAmountOfResources_WhenTheUnitIsCorrectlyInitialized()
        {
            // Arrange
            var unit = new Unit(1, "birenoto chudovishte");
            var resourcesMock = new Mock<IResources>();
            resourcesMock.Setup(x => x.BronzeCoins).Returns(10);
            resourcesMock.Setup(x => x.SilverCoins).Returns(10);
            resourcesMock.Setup(x => x.GoldCoins).Returns(10);
            unit.Resources.Add(resourcesMock.Object);

            var resourcesCostMock = new Mock<IResources>();
            resourcesCostMock.Setup(x => x.BronzeCoins).Returns(5);
            resourcesCostMock.Setup(x => x.SilverCoins).Returns(5);
            resourcesCostMock.Setup(x => x.GoldCoins).Returns(5);

            var expectedGoldAmount = resourcesMock.Object.GoldCoins - resourcesCostMock.Object.GoldCoins;
            var expectedSilverAmount = resourcesMock.Object.SilverCoins - resourcesCostMock.Object.SilverCoins;
            var expectedBronzeAmount = resourcesMock.Object.BronzeCoins - resourcesCostMock.Object.BronzeCoins;

            // Act
            unit.Pay(resourcesCostMock.Object);

            // Assert
            Assert.AreEqual(expectedGoldAmount, unit.Resources.GoldCoins);
        }

        [Test]
        public void ReturnResourceObjectWithTheAmountOfResourcesInTheCostObject_WhenTheUnitIsCorrectlyInitialized()
        {
            // Arrange
            var unit = new Unit(1, "birenoto chudovishte");
            var resourcesMock = new Mock<IResources>();
            resourcesMock.Setup(x => x.BronzeCoins).Returns(10);
            resourcesMock.Setup(x => x.SilverCoins).Returns(10);
            resourcesMock.Setup(x => x.GoldCoins).Returns(10);
            unit.Resources.Add(resourcesMock.Object);

            var resourcesCostMock = new Mock<IResources>();
            resourcesCostMock.Setup(x => x.BronzeCoins).Returns(5);
            resourcesCostMock.Setup(x => x.SilverCoins).Returns(5);
            resourcesCostMock.Setup(x => x.GoldCoins).Returns(5);

            var expectedGoldAmount = resourcesCostMock.Object.GoldCoins;
            var expectedSilverAmount = resourcesCostMock.Object.SilverCoins;
            var expectedBronzeAmount = resourcesCostMock.Object.BronzeCoins;

            // Act
            var res = unit.Pay(resourcesCostMock.Object);

            // Assert
            Assert.IsInstanceOf<IResources>(res);
            Assert.AreEqual(expectedGoldAmount, res.GoldCoins);
            Assert.AreEqual(expectedSilverAmount, res.SilverCoins);
            Assert.AreEqual(expectedBronzeAmount, res.BronzeCoins);
        }
    }
}
