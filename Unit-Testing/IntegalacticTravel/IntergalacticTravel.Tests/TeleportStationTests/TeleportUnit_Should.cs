using System;
using Moq;
using NUnit.Framework;
using IntergalacticTravel.Contracts;
using System.Collections.Generic;
using IntergalacticTravel.Exceptions;
using IntergalacticTravel.Tests.Mocks;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class TeleportUnit_Should
    {
        [Test]
        public void ThrowArgumentNullExceptionWithSpecificMessage_WhenIUnitToTeleportIsNull()
        {
            // Arrange
            var businessOwnerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();
            var station = new TeleportStation(businessOwnerMock.Object, galacticMapMock.Object, locationMock.Object);
            var teleportLocationMock = new Mock<ILocation>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(null, teleportLocationMock.Object));
            StringAssert.Contains("unitToTeleport", ex.Message);
        }

        [Test]
        public void ThrowArgumentNullExceptionWithSpecificMessage_WhenILocationToTeleportIsNull()
        {
            // Arrange
            var businessOwnerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();
            var station = new TeleportStation(businessOwnerMock.Object, galacticMapMock.Object, locationMock.Object);
            var unitMock = new Mock<IUnit>();

            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() => station.TeleportUnit(unitMock.Object, null));
            StringAssert.Contains("destination", ex.Message);
        }

        [Test]
        public void ThrowTeleportOutOfRangeExceptionWithSpecificMessage_WhenUnitPlanetIsDifferentThanTheStations()
        {
            // Arrange
            var businessOwnerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();
            var unitMock = new Mock<IUnit>();
            var targetLocationMock = new Mock<ILocation>();

            var stationPlanetMock = new Mock<IPlanet>();
            var targetPlanetMock = new Mock<IPlanet>();

            var stationGalaxyMock = new Mock<IGalaxy>();
            var targetGalaxyMock = new Mock<IGalaxy>();

            locationMock.SetupGet(x => x.Planet.Name).Returns("Earth");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Chiki-riki");            
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Mars");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Ne Chiki-riki");

            var station = new TeleportStation(businessOwnerMock.Object, galacticMapMock.Object, locationMock.Object);

            // Act & Assert
            var ex = Assert.Throws<TeleportOutOfRangeException>(() => station.TeleportUnit(unitMock.Object, targetLocationMock.Object));
            StringAssert.Contains("unitToTeleport.CurrentLocation", ex.Message);
        }

        [Test]
        public void ThrowInvalidTeleportationLocationExceptionWithSpecificMessage_WhenTargetLocationIsAlreadyTaken()
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

            locationMock.SetupGet(x => x.Planet.Name).Returns("Earth");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Chiki-riki");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Earth");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Chiki-riki");

            targetLocationMock.SetupGet(x => x.Planet.Name).Returns("Mars");
            targetLocationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            targetLocationMock.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            targetLocationMock.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Mars");
            pathMock.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Ne Chiki-riki");

            var otherUnitMock = new Mock<IUnit>();
            otherUnitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Mars");
            otherUnitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            otherUnitMock.SetupGet(x => x.CurrentLocation.Coordinates.Latitude).Returns(1);
            otherUnitMock.SetupGet(x => x.CurrentLocation.Coordinates.Longtitude).Returns(1);
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { otherUnitMock.Object });
            galacticMap.Add(pathMock.Object);
            
            var station = new TeleportStation(businessOwnerMock.Object, galacticMap, locationMock.Object);

            // Act & Assert
            var ex = Assert.Throws<InvalidTeleportationLocationException>(() => station.TeleportUnit(unitMock.Object, targetLocationMock.Object));
            StringAssert.Contains("units will overlap", ex.Message);
        }

        [Test]
        public void ThrowLocationNotFoundExceptionWithSpecificMessage_WhenTargetLocationGalaxyIsNotOnTheMap()
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

            locationMock.SetupGet(x => x.Planet.Name).Returns("Earth");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Chiki-riki");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Earth");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Chiki-riki");

            targetLocationMock.SetupGet(x => x.Planet.Name).Returns("Mars");
            targetLocationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            targetLocationMock.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            targetLocationMock.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Mars");
            pathMock.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Chiki-riki");
            galacticMap.Add(pathMock.Object);

            var station = new TeleportStation(businessOwnerMock.Object, galacticMap, locationMock.Object);

            // Act & Assert
            var ex = Assert.Throws<LocationNotFoundException>(() => station.TeleportUnit(unitMock.Object, targetLocationMock.Object));
            StringAssert.Contains("Galaxy", ex.Message);
        }

        [Test]
        public void ThrowLocationNotFoundExceptionWithSpecificMessage_WhenTargetLocationPlanetIsNotOnTheMap()
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

            locationMock.SetupGet(x => x.Planet.Name).Returns("Earth");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Chiki-riki");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Earth");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Chiki-riki");

            targetLocationMock.SetupGet(x => x.Planet.Name).Returns("Mars");
            targetLocationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            targetLocationMock.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            targetLocationMock.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Ne Mars");
            pathMock.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            galacticMap.Add(pathMock.Object);

            var station = new TeleportStation(businessOwnerMock.Object, galacticMap, locationMock.Object);

            // Act & Assert
            var ex = Assert.Throws<LocationNotFoundException>(() => station.TeleportUnit(unitMock.Object, targetLocationMock.Object));
            StringAssert.Contains("Planet", ex.Message);
        }

        [Test]
        public void ThrowInsufficientResourcesExceptionWithSpecificMessage_WhenUnitDoesNotHaveEnoughBucksToCoverTheCosts()
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

            locationMock.SetupGet(x => x.Planet.Name).Returns("Earth");
            locationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Chiki-riki");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Name).Returns("Earth");
            unitMock.SetupGet(x => x.CurrentLocation.Planet.Galaxy.Name).Returns("Chiki-riki");

            unitMock.Setup(x => x.CanPay(It.IsAny<IResources>())).Returns(false);

            targetLocationMock.SetupGet(x => x.Planet.Name).Returns("Mars");
            targetLocationMock.SetupGet(x => x.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            targetLocationMock.SetupGet(x => x.Coordinates.Latitude).Returns(1);
            targetLocationMock.SetupGet(x => x.Coordinates.Longtitude).Returns(1);

            var pathMock = new Mock<IPath>();
            pathMock.SetupGet(x => x.TargetLocation.Planet.Name).Returns("Mars");
            pathMock.SetupGet(x => x.TargetLocation.Planet.Galaxy.Name).Returns("Ne Chiki-riki");
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { });
            var resourceMock = new Mock<IResources>();
            resourceMock.SetupGet(x => x.GoldCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost).Returns(resourceMock.Object);
            galacticMap.Add(pathMock.Object);

            var station = new TeleportStation(businessOwnerMock.Object, galacticMap, locationMock.Object);

            // Act & Assert
            var ex = Assert.Throws<InsufficientResourcesException>(() => station.TeleportUnit(unitMock.Object, targetLocationMock.Object));
            StringAssert.Contains("FREE LUNCH", ex.Message);
        }

        [Test]
        public void RequirePayment_WhenUnitPassesAllOfTheRequirements()
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
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { });
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

            // Assert
            unitMock.Verify(x => x.Pay(It.IsAny<IResources>()), Times.Once);
        }

        [Test]
        public void ObtainPaymentAndIncreaseResourses_WhenUnitPassesAllOfTheRequirements()
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
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { });
            var resourceMock = new Mock<IResources>();
            resourceMock.SetupGet(x => x.GoldCoins).Returns(10);
            resourceMock.SetupGet(x => x.BronzeCoins).Returns(10);
            resourceMock.SetupGet(x => x.SilverCoins).Returns(10);
            pathMock.SetupGet(x => x.Cost).Returns(resourceMock.Object);
            galacticMap.Add(pathMock.Object);

            unitMock.SetupGet(x => x.CurrentLocation.Planet.Units).Returns(new List<IUnit>() { });
            unitMock.Setup(x => x.Pay(It.IsAny<IResources>())).Returns(resourceMock.Object);

            var station = new TeleportStationMock(businessOwnerMock.Object, galacticMap, locationMock.Object);

            var initialGoldAmount = station.Resources.GoldCoins;
            var initialBronzeAmount = station.Resources.BronzeCoins;
            var initialSilverAmount = station.Resources.SilverCoins;

            var expectedGoldAmount = initialGoldAmount + pathMock.Object.Cost.GoldCoins;
            var expectedBronzeAmount = initialGoldAmount + pathMock.Object.Cost.BronzeCoins;
            var expectedSilverAmount = initialGoldAmount + pathMock.Object.Cost.SilverCoins;

            // Act
            station.TeleportUnit(unitMock.Object, targetLocationMock.Object);

            // Assert
            Assert.AreEqual(expectedGoldAmount, station.Resources.GoldCoins);
            Assert.AreEqual(expectedBronzeAmount, station.Resources.BronzeCoins);
            Assert.AreEqual(expectedSilverAmount, station.Resources.SilverCoins);
        }

        [Test]
        public void SetTheUnitsPreviousLocationToUnitsCurrentLocation_WhenUnitIsTeleported()
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
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { });
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

            // Assert
            unitMock.VerifySet(x => x.PreviousLocation = x.CurrentLocation, Times.Once);
        }

        [Test]
        public void SetTheUnitsCurrentLocationToTargetLocation_WhenUnitIsTeleported()
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
            pathMock.SetupGet(x => x.TargetLocation.Planet.Units).Returns(new List<IUnit>() { });
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

            // Assert
            unitMock.VerifySet(x => x.CurrentLocation = targetLocationMock.Object, Times.Once);
        }

        [Test]
        public void AddTheUnitToTheListOFUnitsOfTheTargetLocation_WhenUnitIsTeleported()
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

            // Assert
            pathMock.Verify(x => x.TargetLocation.Planet.Units.Add(unitMock.Object), Times.Once);
        }

        [Test]
        public void RemoveTheUnitFromTheListOFUnitsOfThePreviousLocation_WhenUnitIsTeleported()
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

            // Assert
            unitMock.Verify(x => x.CurrentLocation.Planet.Units.Remove(unitMock.Object), Times.Once);
        }
    }
}
