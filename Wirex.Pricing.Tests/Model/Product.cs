using System;
using Wirex.Pricing.Tests.Contract;

namespace Wirex.Pricing.Tests.Model
{
    public class Product : ICloneable<Product>
    {
        public Product(decimal price)
        {
            Price = price;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public decimal Price { get; set; }

        public Product Clone()
        {
            return new Product(Price) {Id = Id};
        }
    }
}