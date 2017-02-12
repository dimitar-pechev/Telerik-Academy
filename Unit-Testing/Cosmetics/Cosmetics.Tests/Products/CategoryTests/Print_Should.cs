using NUnit.Framework;
using System.Text;
using Cosmetics.Engine;
using Cosmetics.Tests.Products.Mocks;

namespace Cosmetics.Tests.Products.CategoryTests
{
    [TestFixture]
    public class Print_Should
    {
        [Test]
        public void ReturnAStringWithTheCategoryDetailsInTheCorrectFormat()
        {
            // Arrange
            var category = new CategoryMock("name");

            var expectedResult = string.Format("{0} category - {1} {2} in total", category.Name,
                category.Products.Count, category.Products.Count != 1 ? "products" : "product");

            // Act
            var message = category.Print();

            // Assert
            Assert.AreEqual(expectedResult.ToString(), message);
        }
    }
}
