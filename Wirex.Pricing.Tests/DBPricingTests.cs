using FluentAssertions;
using Wirex.Pricing.Tests.Contract;
using Wirex.Pricing.Tests.Discounts;
using Wirex.Pricing.Tests.Entities;
using Wirex.Pricing.Tests.Services;
using Xunit;

namespace Wirex.Pricing.Tests
{
    public class DbPricingTests
    {
        private readonly BasketService _sut;

        public DbPricingTests()
        {
            var percentageDiscountHandler = new PercentageDiscountHandler();
            var buyTwoDiscountHandler = new BuyTwoGetOneDiscountHandler();
            _sut = new BasketService(new IDiscountHandler[] {percentageDiscountHandler, buyTwoDiscountHandler});
        }
        

        [Theory]
        [InlineData(100, 30, 70)]
        [InlineData(100, 50, 50)]
        [InlineData(300, 50, 150)]
        public void Percentage(decimal price, decimal percentage, decimal expected)
        {
            var product = new ProductEntity{Price = price};
            var record = new BasketRecordEntity {Count = 1, Product = product};
            var basket = new BasketEntity
            {
                Records = new[] {record}
            };
            var percentageDiscount = new DiscountEntity
            {
                Type = DiscountEntityType.Percentage,
                Percentage = percentage,
                TargetProduct = product
            };

            var dbPrice = _sut.CalculatePrice(basket);
            var basketModel = _sut.CalculatePriceWithDiscounts(basket, new[] {percentageDiscount});
            var basketModelPrice = _sut.CalculatePrice(basketModel);

            dbPrice.Should().Be(price);
            basketModelPrice.Should().Be(expected);
        }

        [Theory]
        [InlineData(100, 1, 1, 100)]
        [InlineData(100, 2, 3, 200)]
        [InlineData(100, 3, 4, 300)]
        [InlineData(100, 4, 6, 400)]
        [InlineData(100, 5, 7, 500)]
        [InlineData(100, 6, 9, 600)]
        public void BuyTwoGetOneFree(decimal price, int count, int expectedCount, decimal expectedPrice)
        {
            var product = new ProductEntity {Price = price};
            var record = new BasketRecordEntity {Count = count, Product = product};
            var basket = new BasketEntity
            {
                Records = new[] {record}
            };
            var percentageDiscount = new DiscountEntity
            {
                Type = DiscountEntityType.BuyTwoGetOneForFree,
                TargetProduct = product,
                RewardProduct = product,
            };

            var dbPrice = _sut.CalculatePrice(basket);
            var basketModel = _sut.CalculatePriceWithDiscounts(basket, new[] {percentageDiscount});
            var basketModelPrice = _sut.CalculatePrice(basketModel);
            var basketModelProductCount = basketModel.Records[0].Count + basketModel.Records[0].FreeProducts.Count;

            dbPrice.Should().Be(price * record.Count);
            basketModelPrice.Should().Be(expectedPrice);
            basketModelProductCount.Should().Be(expectedCount);
        }
    }
}