using System;
using NUnit.Framework;
using Cosmetics.Engine;
using System.Collections.Generic;

namespace Cosmetics.Tests.Engine.CosmeticsFactoryTests
{
    [TestFixture]
    public class CreateToothpaste_Should
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullRefException_WhenThePassedNameParamIsNullOrEmpty(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, "brand", 3.1m, 0, new List<string>() { "random stuff" }));
        }

        [Test]
        [TestCase("aa")]
        [TestCase("01234567891")]
        public void ThrowIndexOutOfRangeException_WhenThePassedNameParamLengthIsOutOfThePermittedRange(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "brand", 3.1m, 0, new List<string>() { "random stuff" }));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ThrowNullRefException_WhenThePassedBrandParamIsNullOrEmpty(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<NullReferenceException>(() => factory.CreateToothpaste(name, "brand", 3.1m, 0, new List<string>() { "random stuff" }));
        }

        [Test]
        [TestCase("a")]
        [TestCase("01234567891")]
        public void ThrowIndexOutOfRangeException_WhenThePassedBrandParamLengthIsOutOfThePermittedRange(string name)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste(name, "brand", 3.1m, 0, new List<string>() { "random stuff" }));
        }

        [Test]
        [TestCase("a")]
        [TestCase("01234567891asasdasds")]
        public void ThrowIndexOutOfRangeException_WhenThePassedIngredientsItemParamLengthIsOutOfThePermittedRange(string item)
        {
            //Arrange
            var factory = new CosmeticsFactory();

            // Act & Assert
            Assert.Throws<IndexOutOfRangeException>(() => factory.CreateToothpaste("name", "brand", 3.1m, 0, new List<string>() { item }));
        }
    }
}
