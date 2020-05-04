using System;
using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Discounts
{
    public class BuyTwoGetOneForFreeDiscount: IDiscount
    {
        public BuyTwoGetOneForFreeDiscount(Product target, Product reward)
        {
            Target = target;
            Reward = reward;
        }
        public Product Target { get; }
        public Product Reward { get; }

        public bool IsApplicable(BasketItem item)
        {
            return item.Count / 2 >= 1 && Target.Id == item.Product.Id;
        }

        public BasketItem Apply(BasketItem item)
        {
            var amountOfItemsToDiscount = (int) Math.Floor(item.Count / 2f);
            for (int i = 0; i < amountOfItemsToDiscount; i++)
            {
                item.FreeProducts.Add(Reward);    
            }
            
            return item;
        }
    }
}