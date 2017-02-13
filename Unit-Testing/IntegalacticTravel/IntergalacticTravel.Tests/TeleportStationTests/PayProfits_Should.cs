using IntergalacticTravel.Contracts;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class PayProfits_Should
    {
        [Test]
        public void ReturnTheTotalAmounOfResourcesGeneratedByTheStation_WhenItIsCalledByTheOwnerOfTheStation()
        {
            // Arrange
            var businessOwnerMock = new Mock<IBusinessOwner>();
            var galacticMap = new List<IPath>();
            var locationMock = new Mock<ILocation>();
            var unitMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            var stationPlanetMock = new Mock<IPlanet>();
            var targetPlanetMock = new Mock<IPlanet>();

            var stationGalaxyMock = new Mock<IGalaxy>();
            var targetGalaxyMock = new Mock<IGalaxy>();

            businessOwnerMock.SetupGet(x => x.IdentificationNumber).Returns(1);

            locationMock.SetupGet(x => x.Planet.Name).Returns("Earth");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Chiki-riki");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Earth");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Chiki-riki");

            unitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(true);
            unitMock.SetupGet(x => x.Resources.GoldCoins).Returns(10);
            unitMock.SetupGet(x => x.Resources.BronzeCoins).Returns(10);
            unitMock.SetupGet(x => x.Resources.SilverCoins).Returns(10);

            targetLocationMock.SetupGet(x => x.Planet.Name).Returns("Mars");
            targetLocationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            targetLocationMock.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            targetLocationMock.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Mars");
            pathMock.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            var units = new List<IUnit>();
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(units);
            var resourceMock = new Mock<IResources>();
            resourceMock.SetupGet(x => x.GoldCoins).Returns(10);
            resourceMock.SetupGet(x => x.BronzeCoins).Returns(10);
            resourceMock.SetupGet(x => x.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost).Returns(resourceMock.Object);
            galacticMap.Add(pathMock.Object);

            unitMock.SetupGet(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { });
            unitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourceMock.Object);

            var station = new TeleportStation(businessOwnerMock.Object, galacticMap, locationMock.Object);

            // Act
            station.TeleportUnit(unitMock.Object, targetLocationMock.Object);
            var resources = station.PayProfits(businessOwnerMock.Object);

            // Assert
            Assert.AreEqual(10, resources.BronzeCoins);
            Assert.AreEqual(10, resources.SilverCoins);
            Assert.AreEqual(10, resources.GoldCoins);
        }
    }
}
