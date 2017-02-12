using System;
using Moq;
using NUnit.Framework;
using Cosmetics.Engine;
using Cosmetics.Products;

namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    [TestFixture]
    public class CreateShampoo_Should
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullRefException_WhenThePassedNameParamIsNullOrEmpty(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "brand", 2.1m, 0, 200, 0));
        }
        
        [Test]
        [TestCase("aa")]
        [TestCase("01234567891")]
        public void ThrowIndexOutOfRangeException_WhenThePassedNameParamLengthIsOutOfThePermittedRange(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "brand", 2.1m, 0, 200, 0));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullRefException_WhenThePassedBrandParamIsNullOrEmpty(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateShampoo(name, "brand", 2.1m, 0, 200, 0));
        }

        [Test]
        [TestCase("a")]
        [TestCase("01234567891")]
        public void ThrowIndexOutOfRangeException_WhenThePassedBrandParamLengthIsOutOfThePermittedRange(string name)
        { 
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateShampoo(name, "brand", 2.1m, 0, 200, 0));
        }

        [Test]
        public void ReturnShampooInstance_WhenInputParamsAreValid()
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act
            var shampoo = factory.CreateShampoo("bokluk", "brand", 2.1m, 0, 200, 0);

            // Assert
            Assert.IsInstanceOf<Shampoo>(shampoo);
        }
    }
}
