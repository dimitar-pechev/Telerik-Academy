using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Contracts;

namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    [TestFixture]
    public class CreateShoppingCart_Should
    {
        [Test]
        public void AlwaysReturnANewShoppingCartInstance()
        {
            // Arrange
            var factory = new CosmeticsFactory();

            // Act
            var firstCart = factory.CreateShoppingCart();
            var secondCart = factory.CreateShoppingCart();

            // Assert
            Assert.IsInstanceOf<IShoppingCart>(firstCart);
            Assert.IsInstanceOf<IShoppingCart>(secondCart);
            Assert.AreNotSame(firstCart, secondCart);
        }
    }
}
