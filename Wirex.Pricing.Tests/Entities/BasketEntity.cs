using System;
using System.Collections.Generic;

namespace Wirex.Pricing.Tests.Entities
{
    public class BasketEntity
    {
        public Guid Id { get; set; }
        public IList<BasketRecordEntity> Records { get; set; }
        
    }
}