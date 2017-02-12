using Cosmetics.Engine;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests.Engine
{
    [TestFixture]
    public class CreateCategory_Should
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullRefException_WhenThePassedNameParamIsNullOrEmpty(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateCategory(name));
        }

        [Test]
        [TestCase("a")]
        [TestCase("0123456789123456")]
        public void ThrowIndexOutOfRangeException_WhenThePassedNameParamLengthIsOutOfThePermittedRange(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateCategory(name));
        }

        [Test]
        public void ReturnShampooInstance_WhenInputParamsAreValid()
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act
            var category = factory.CreateCategory("bokluk");

            // Assert
            Assert.IsInstanceOf<Category>(category);
        }
    }
}
