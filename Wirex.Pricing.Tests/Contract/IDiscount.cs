using Wirex.Pricing.Tests.Model;

namespace Wirex.Pricing.Tests.Contract
{
    public interface IDiscount
    {
        public bool IsApplicable(BasketItem item);
        public BasketItem Apply(BasketItem item);
    }
}