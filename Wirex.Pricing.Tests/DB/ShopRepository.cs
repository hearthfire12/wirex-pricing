using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Wirex.Pricing.Tests.Entities;

namespace Wirex.Pricing.Tests.DB
{
    public interface IShopRepository
    {
        Task<BasketEntity> GetBasketAsync(Guid basketId);
        Task<IEnumerable<DiscountEntity>> GetAvailableDiscounts();
    }
}