using System;
using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Entities;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.DiscountHandlers
{
    public class BuyTwoGetOneDiscountHandler : IDiscountHandler
    {
        public bool CanHandle(DiscountEntity discount)
        {
            return discount.Type == DiscountEntityType.BuyTwoGetOneForFree;
        }

        public bool IsApplicable(BasketRecordEntity record, DiscountEntity entity)
        {
            return record.Count / 2 >= 1 && record.Product.Id == entity.TargetProduct.Id;
        }

        public BasketRecordModel Apply(BasketRecordEntity record, DiscountEntity entity)
        {
            var recordModel = new BasketRecordModel(record.Count, new ProductModel(record.Product.Price));
            var amountOfItemsToDiscount = (int) Math.Floor(record.Count / 2f);
            for (int i = 0; i < amountOfItemsToDiscount; i++)
            {
                recordModel.FreeProducts.Add(new ProductModel(entity.RewardProduct.Price));
            }

            return recordModel;
        }
    }
}