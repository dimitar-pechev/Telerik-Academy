using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.Mocks;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace IntergalacticTravel.Tests.TeleportStationTests
{
    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void SetUpAllTheProvidedFields_WhenANewStationIsCreatedWithValidParams()
        {
            // Arrange
            var businessOwnerMock = new Mock<IBusinessOwner>();
            var galacticMapMock = new Mock<IEnumerable<IPath>>();
            var locationMock = new Mock<ILocation>();

            // Act 
            var station = new TeleportStationMock(businessOwnerMock.Object, galacticMapMock.Object, locationMock.Object);

            // Assert
            Assert.AreSame(businessOwnerMock.Object, station.Owner);
            Assert.AreSame(galacticMapMock.Object, station.GalacticMap);
            Assert.AreSame(locationMock.Object, station.Location);
        }
    }
}
