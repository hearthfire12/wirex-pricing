using System.Collections.Generic;
using System.Linq;
using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Services
{
    public class BasketService
    {
        public decimal CalculatePrice(Basket basket)
        {
            return basket.Items.Sum(x => x.Count * x.Product.Price);
        }

        public decimal CalculatePriceWithDiscounts(Basket basket, IEnumerable<IDiscount> discounts)
        {
            // basket = basket.Clone();
            foreach (var discount in discounts)
            {
                for (int i = 0; i < basket.Items.Count; i++)
                {
                    var basketItem = basket.Items[i];
                    if (discount.IsApplicable(basketItem))
                    {
                        basket.Items[i] = discount.Apply(basketItem);
                    }
                }
            }

            return CalculatePrice(basket);
        }
    }
}