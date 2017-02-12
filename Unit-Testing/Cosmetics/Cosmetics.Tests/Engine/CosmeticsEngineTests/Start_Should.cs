using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Cosmetics.Contracts;
using Cosmetics.Tests.Engine.Mocks;
using Cosmetics.Common;
using System.Linq;

namespace Cosmetics.Tests.Engine.CosmeticsEngineTests
{
    [TestFixture]
    public class Start_Should
    {
        [Test]
        public void ExecuteCreateCategoryCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();

            var commandName = "CreateCategory";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            var commandParam = "ForMale";
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParam });

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            factoryMock.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(categoryMock.Object);
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);

            // Act
            engineMock.Start();

            // Arrange
            Assert.AreEqual(1, engineMock.Categories.Count);
            Assert.AreSame(categoryMock.Object, engineMock.Categories[commandParam]);
        }

        [Test]
        public void ExecuteAddToCategoryCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            var commandName = "AddToCategory";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            var commandParamCategory = "ForMale";
            var commandParamProduct = "neshto";
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamCategory, commandParamProduct });

            productMock.SetupGet(x => x.Name).Returns(commandParamProduct);

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamCategory, categoryMock.Object);
            engineMock.Products.Add(commandParamProduct, productMock.Object);

            // Act
            engineMock.Start();

            // Arrange
            categoryMock.Verify(x => x.AddProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void ExecuteRemoveFromCategoryCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            var commandName = "RemoveFromCategory";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            var commandParamCategory = "ForMale";
            var commandParamProduct = "neshto";
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamCategory, commandParamProduct });

            productMock.SetupGet(x => x.Name).Returns(commandParamProduct);

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamCategory, categoryMock.Object);
            engineMock.Products.Add(commandParamProduct, productMock.Object);

            // Act
            engineMock.Start();

            // Arrange
            categoryMock.Verify(x => x.RemoveProduct(productMock.Object), Times.Once);
        }

        [Test]
        public void ExecuteShowCategoryCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var productMock = new Mock<IProduct>();

            var commandName = "ShowCategory";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            var commandParamCategory = "ForMale";
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamCategory });

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamCategory, categoryMock.Object);

            // Act
            engineMock.Start();

            // Arrange
            categoryMock.Verify(x => x.Print(), Times.Once);
        }


        [Test]
        public void ExecuteCreateShampooCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var shampooMock = new Mock<IShampoo>();

            var commandName = "CreateShampoo";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            var commandParamName = "Novoto";
            var commandParamBrand = "Pervol";
            var commandParamPrice = "100";
            var commandParamGender = "men";
            var commandParamMililiters = "200";
            var commandParamUsage = "everyday";
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamName, commandParamBrand,
                commandParamPrice, commandParamGender, commandParamMililiters, commandParamUsage });

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamName, categoryMock.Object);
            factoryMock.Setup(x => x.CreateShampoo(commandParamName, commandParamBrand,
                decimal.Parse(commandParamPrice), (GenderType)0, uint.Parse(commandParamMililiters), (UsageType)0)).Returns(shampooMock.Object);

            // Act
            engineMock.Start();

            // Arrange
            Assert.AreEqual(1, engineMock.Products.Count);
            Assert.AreSame(shampooMock.Object, engineMock.Products[commandParamName]);
        }

        [Test]
        public void ExecuteCreateToothPasteCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var toothpaseMock = new Mock<IToothpaste>();

            var commandName = "CreateToothpaste";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            var commandParamName = "Novoto";
            var commandParamBrand = "Pervol";
            var commandParamPrice = "100";
            var commandParamGender = "men";
            var commandParamIngredients = "bokluci,razni";
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamName, commandParamBrand,
                commandParamPrice, commandParamGender, commandParamIngredients });

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamName, categoryMock.Object);
            factoryMock.Setup(x => x.CreateToothpaste(commandParamName, commandParamBrand,
                decimal.Parse(commandParamPrice), (GenderType)0, new List<string>() { "bokluci", "razni" })).Returns(toothpaseMock.Object);

            // Act
            engineMock.Start();

            // Arrange
            Assert.AreEqual(1, engineMock.Products.Count);
            Assert.AreSame(toothpaseMock.Object, engineMock.Products[commandParamName]);
        }

        [Test]
        public void ExecuteAddToShoppingCartCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var toothpaseMock = new Mock<IToothpaste>();

            var commandName = "AddToShoppingCart";
            var commandParamName = "Novoto";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamName });

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamName, categoryMock.Object);
            engineMock.Products.Add(commandParamName, toothpaseMock.Object);
           
            // Act
            engineMock.Start();

            // Arrange
            shoppingCartMock.Verify(x => x.AddProduct(toothpaseMock.Object), Times.Once);
        }

        [Test]
        public void ExecuteRemoveFromShoppingCartCommand_WhenInputParamsAreInTheCorrectFormat()
        {
            // Arrange
            var factoryMock = new Mock<ICosmeticsFactory>();
            var shoppingCartMock = new Mock<IShoppingCart>();
            var commandParserMock = new Mock<ICommandParser>();
            var commandMock = new Mock<ICommand>();
            var categoryMock = new Mock<ICategory>();
            var toothpaseMock = new Mock<IToothpaste>();

            var commandName = "RemoveFromShoppingCart";
            var commandParamName = "Novoto";
            commandMock.SetupGet(x => x.Name).Returns(commandName);
            commandMock.SetupGet(x => x.Parameters).Returns(new List<string> { commandParamName });

            commandParserMock.Setup(x => x.ReadCommands()).Returns(new List<ICommand>() { commandMock.Object });
            var engineMock = new CosmeticsEngineMock(factoryMock.Object, shoppingCartMock.Object, commandParserMock.Object);
            engineMock.Categories.Add(commandParamName, categoryMock.Object);
            engineMock.Products.Add(commandParamName, toothpaseMock.Object);
            shoppingCartMock.Setup(x => x.ContainsProduct(toothpaseMock.Object)).Returns(true);

            // Act
            engineMock.Start();

            // Arrange
            shoppingCartMock.Verify(x => x.RemoveProduct(toothpaseMock.Object), Times.Once);
        }
    }
}