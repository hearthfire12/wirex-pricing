using System.Collections.Generic;

namespace Wirex.Pricing.Tests.Model
{
    public class BasketRecordModel
    {
        public BasketRecordModel(int count, ProductModel product)
        {
            Count = count;
            Product = product;
        }

        public int Count { get; set; }
        public ProductModel Product { get; set; }
        public ICollection<ProductModel> FreeProducts { get; set; } = new List<ProductModel>();
    }
}