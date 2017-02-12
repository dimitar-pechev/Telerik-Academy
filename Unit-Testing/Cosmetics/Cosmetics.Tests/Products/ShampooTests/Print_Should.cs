using NUnit.Framework;
using System.Text;
using Cosmetics.Engine;

namespace Cosmetics.Tests.Products.ShampooTests
{
    [TestFixture]
    public class Print_Should
    {
        [Test]
        public void ReturnAStringWithTheShampooDetailsInTheCorrectFormat()
        {
            // Arrange
            var factory = new CosmeticsFactory();
            var shampoo = factory.CreateShampoo("name", "brand", 2.1m, 0, 200, 0);

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- brand - name:");
            expectedResult.AppendLine("  * Price: $420.0");
            expectedResult.AppendLine("  * For gender: Men");
            expectedResult.AppendLine("  * Quantity: 200 ml");
            expectedResult.Append("  * Usage: EveryDay");

            // Act
            var message = shampoo.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), message);
        }
    }
}
