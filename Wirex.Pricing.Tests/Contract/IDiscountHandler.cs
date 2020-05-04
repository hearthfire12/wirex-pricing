using Wirex.Pricing.Tests.Entities;
using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Contract
{
    public interface IDiscountHandler
    {
        bool CanHandle(DiscountEntity discount);
        bool IsApplicable(BasketRecordEntity record, DiscountEntity entity);
        BasketRecordModel Apply(BasketRecordEntity record, DiscountEntity entity);
    }
}