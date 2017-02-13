using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.BuisinessOwnerTests
{
    [TestFixture]
    public class CollectProfits_Should
    {
        [Test]
        public void IncreaseTheOwnersResourcesFromHisTeleportStations()
        {
            // Arrange
            var firstStationMock = new Mock<ITeleportStation>();
            var stations = new List<ITeleportStation>() { firstStationMock.Object };

            var owner = new BusinessOwner(1, "nickname", stations);

            var resourseMock = new Mock<IResources>();
            resourseMock.Setup(x => x.BronzeCoins).Returns(10);
            resourseMock.Setup(x => x.SilverCoins).Returns(10);
            resourseMock.Setup(x => x.GoldCoins).Returns(10);
            firstStationMock.Setup(x => x.PayProfits(owner)).Returns(resourseMock.Object);

            // Act
            owner.CollectProfits();

            // Assert
            Assert.AreEqual(10, owner.Resources.GoldCoins);
            Assert.AreEqual(10, owner.Resources.BronzeCoins);
            Assert.AreEqual(10, owner.Resources.SilverCoins);
        }
    }
}
