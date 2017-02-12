using System.Text;
using NUnit.Framework;
using Cosmetics.Engine;
using System.Collections.Generic;

namespace Cosmetics.Tests.Products.ToothpasteTests
{
    [TestFixture]
    class Print_Should
    {
        [Test]
        public void ReturnAStringWithTheToothpasteDetailsInTheCorrectFormat()
        {
            // Arrange
            var factory = new CosmeticsFactory();
            var toothpaste = factory.CreateToothpaste("name", "brand", 2.1m, 0, new List<string> { "sddasd" } );

            var expectedResult = new StringBuilder();
            expectedResult.AppendLine("- brand - name:");
            expectedResult.AppendLine("  * Price: $2.1");
            expectedResult.AppendLine("  * For gender: Men");
            expectedResult.Append($"  * Ingredients: {string.Join(", ", toothpaste.Ingredients)}");

            // Act
            var message = toothpaste.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), message);
        }
    }
}
