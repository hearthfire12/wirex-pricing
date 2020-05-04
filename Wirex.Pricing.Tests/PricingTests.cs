using FluentAssertions;
using Wirex.Pricing.Tests.Discounts;
using Wirex.Pricing.Tests.Model;
using Wirex.Pricing.Tests.Services;
using Xunit;

namespace Wirex.Pricing.Tests
{
    public class PricingTests
    {
        private readonly BasketService _sut = new BasketService();

        [Theory]
        [InlineData(100, 30, 70)]
        [InlineData(100, 50, 50)]
        [InlineData(300, 50, 150)]
        public void Percentage(decimal price, decimal percentage, decimal expected)
        {
            var product = new Product(price: price);
            var basketItem = new BasketItem(count: 1, product);
            var basket = new Basket {Items = new[] {basketItem}};
            var discount = new PercentageDiscount(product, percentage: percentage);

            var basketPrice = _sut.CalculatePrice(basket);
            var discountedPrice = _sut.CalculatePriceWithDiscounts(basket, new[] {discount});

            basketPrice.Should().Be(price);
            discountedPrice.Should().Be(expected);
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
            var product = new Product(price: price);
            var basketItem = new BasketItem(count: count, product);
            var basket = new Basket {Items = new[] {basketItem}};
            var discount = new BuyTwoGetOneForFreeDiscount(target: product.Clone(), reward: product.Clone());
            
            var basketPrice = _sut.CalculatePrice(basket);
            var discountedPrice = _sut.CalculatePriceWithDiscounts(basket, new[] {discount});

            basketPrice.Should().Be(price * count);
            (basket.Items[0].Count + basket.Items[0].FreeProducts.Count).Should().Be(expectedCount);
            discountedPrice.Should().Be(expectedPrice);
        }
    }
}