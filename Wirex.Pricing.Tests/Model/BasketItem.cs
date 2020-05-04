using System.Collections.Generic;
using Wirex.Pricing.Tests.Contract;

namespace Wirex.Pricing.Tests.Model
{
    public class BasketItem: ICloneable<BasketItem>
    {
        public BasketItem(int count, Product item)
        {
            Count = count;
            Product = item;
        }
        public int Count { get; }
        public Product Product { get; }

        public ICollection<Product> FreeProducts { get; } = new List<Product>();
        public BasketItem Clone()
        {
            return new BasketItem(Count, Product.Clone());
        }
    }
}