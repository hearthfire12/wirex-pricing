using System.Collections.Generic;
using System.Linq;
using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Entities;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Services
{
    public class BasketService : IBasketService
    {
        private readonly IEnumerable<IDiscountHandler> _handlers;

        public BasketService(IEnumerable<IDiscountHandler> handlers)
        {
            _handlers = handlers;
        }
        
        public decimal CalculatePrice(BasketEntity basket)
        {
            return basket.Records.Sum(x => x.Count * x.Product.Price);
        }
        
        public decimal CalculatePrice(BasketModel basket)
        {
            return basket.Records.Sum(x => x.Count * x.Product.Price);
        }

        public BasketModel CalculatePriceWithDiscounts(BasketEntity basket, IEnumerable<DiscountEntity> discounts)
        {
            var basketModel = new BasketModel();
            foreach (var discount in discounts)
            {
                var handler = _handlers.SingleOrDefault(x => x.CanHandle(discount));
                foreach (var record in basket.Records)
                {
                    if (handler != null && handler.IsApplicable(record, discount))
                    {
                        basketModel.Records.Add(handler.Apply(record, discount));   
                    }
                    else
                    {
                        basketModel.Records.Add(new BasketRecordModel(record.Count,
                            new ProductModel(record.Product.Price)));
                    }
                }
            }

            return basketModel;
        }
    }
}