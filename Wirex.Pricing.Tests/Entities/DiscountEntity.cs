using System;

namespace Wirex.Pricing.Tests.Entities
{
    public class DiscountEntity
    {
        public Guid Id { get; set; }
        public DiscountEntityType Type { get; set; }
        public ProductEntity TargetProduct { get; set; }
        public ProductEntity RewardProduct { get; set; }
        public decimal Percentage { get; set; }
    }
}