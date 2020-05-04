using System.Collections.Generic;
using Wirex.Pricing.Tests.Entities;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Contract
{
    public interface IBasketService
    {
        decimal CalculatePrice(BasketModel basket);
        decimal CalculatePrice(BasketEntity basket);
        BasketModel CalculatePriceWithDiscounts(BasketEntity basket, IEnumerable<DiscountEntity> discounts);
    }
}