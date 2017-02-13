using System;
using NUnit.Framework;

namespace IntergalacticTravel.Tests.ResourcesFactoryTests
{
    [TestFixture]
    public class GetResources_Should
    {
        [Test]
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void ReturnANewlyCreatedResourcesObjectWithCorrectlySetUpProps_WhenInputParamsAreValid(string command)
        {
            // Arrange
            var factory = new ResourcesFactory();
            var expectedAmountGold = 20;
            var expectedAmountSilver = 30;
            var expectedAmountBronze = 40;

            // Act 
            var resources = factory.GetResources(command);

            // Assert
            Assert.IsInstanceOf<Resources>(resources);
            Assert.AreEqual(expectedAmountGold, resources.GoldCoins);
            Assert.AreEqual(expectedAmountSilver, resources.SilverCoins);
            Assert.AreEqual(expectedAmountBronze, resources.BronzeCoins);
        }

        [Test]
        [TestCase("create resources x y z")]
        [TestCase("tansta resources a b")]
        [TestCase("absolutelyRandomStringThatMustNotBeAValidCommand")]
        [TestCase("Samo Liverpool!")]
        public void ThrowInvalidOperationException_WhenCommandIsInvalid(string command)
        {
            // Arrange
            var factory = new ResourcesFactory();

            // Act & Assert
            var ex = Assert.Throws<InvalidOperationException>(() => factory.GetResources(command));
            StringAssert.Contains("command", ex.Message);
        }

        [Test]
        [TestCase("create resources silver(10) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(555555555555555555555555555555555) gold(97853252356623523532999999999) bronze(20)")]
        [TestCase("create resources silver(10) gold(20) bronze(4444444444444444444444444444444444444)")]
        [TestCase("create resources silver(1222222222222222222220) gold(202222222222222222222222222) bronze(4444444444444444444444444444444444444)")]
        public void ThrowOveflowException_WhenCommandIsInValidFormatButResourcesAmountIsTooLarge(string command)
        {
            // Arrange
            var factory = new ResourcesFactory();

            // Act & Assert
            Assert.Throws<OverflowException>(() => factory.GetResources(command));
        }
    }
}
