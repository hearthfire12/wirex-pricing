using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Discounts
{
    public class PercentageDiscount: IDiscount
    {
        public PercentageDiscount(Product product, decimal percentage)
        {
            Product = product;
            Percentage = percentage;
        }
        public Product Product { get; }
        public decimal Percentage { get; }
        
        public bool IsApplicable(BasketItem item)
        {
            return Product.Id == item.Product.Id;
        }

        public BasketItem Apply(BasketItem item)
        {
            var discountAmount = Product.Price * Percentage / 100;
            item.Product.Price -= discountAmount;
            return item;
        }
    }
}