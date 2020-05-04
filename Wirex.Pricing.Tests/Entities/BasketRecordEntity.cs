using System;

namespace Wirex.Pricing.Tests.Entities
{
    public class BasketRecordEntity
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public ProductEntity Product { get; set; }
    }
}