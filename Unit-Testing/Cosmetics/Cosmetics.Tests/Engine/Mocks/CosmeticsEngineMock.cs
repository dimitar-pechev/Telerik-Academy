using Cosmetics.Contracts;
using Cosmetics.Engine;
using System.Collections.Generic;

namespace Cosmetics.Tests.Engine.Mocks
{
    internal class CosmeticsEngineMock : CosmeticsEngine
    {
        public CosmeticsEngineMock(ICosmeticsFactory factory, IShoppingCart shoppingCart, ICommandParser commandParser)
            : base(factory, shoppingCart, commandParser)
        {
        }

        public IDictionary<string, ICategory> Categories
        {
            get
            {
                return this.categories;
            }
        }

        public IDictionary<string, IProduct> Products
        {
            get
            {
                return this.products;
            }
        }
    }
}
