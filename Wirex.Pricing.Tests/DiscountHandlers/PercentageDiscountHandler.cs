using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Entities;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.DiscountHandlers
{
    public class PercentageDiscountHandler: IDiscountHandler {
        public bool CanHandle(DiscountEntity discount)
        {
            return discount.Type == DiscountEntityType.Percentage;
        }

        public bool IsApplicable(BasketRecordEntity record, DiscountEntity entity)
        {
            return record.Product.Id == entity.TargetProduct.Id;
        }

        public BasketRecordModel Apply(BasketRecordEntity record, DiscountEntity entity)
        {
            var discountAmount = record.Product.Price * entity.Percentage / 100;
            record.Product.Price -= discountAmount;
            return new BasketRecordModel(record.Count, new ProductModel(record.Product.Price));
        }
    }
}