using System.Collections.Generic;

namespace Wirex.Pricing.Tests.Model
{
    public class BasketModel 
    {
        public IList<BasketRecordModel> Records { get; set; } = new List<BasketRecordModel>();
    }
}