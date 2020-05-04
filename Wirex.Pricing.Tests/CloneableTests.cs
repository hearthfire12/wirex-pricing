using FluentAssertions;
using Wirex.Pricing.Tests.Model;
using Xunit;

namespace Wirex.Pricing.Tests
{
    public class CloneableTests
    {
        [Fact]
        public void ShopItem()
        {
            var shopItem = new Product(100);
            var clone = shopItem.Clone();

            clone.Price = 200;

            shopItem.Price.Should().Be(100);
            clone.Price.Should().Be(200);
        }
        
        [Fact]
        public void BasketItem()
        {
            var shopItem = new Product(100);
            var basketItem = new BasketItem(1, shopItem);
            var clone = basketItem.Clone();

            clone.Product.Price = 200;

            basketItem.Product.Price.Should().Be(100);
            clone.Product.Price.Should().Be(200);
        }
        
        [Fact]
        public void Basket()
        {
            var shopItem = new Product(100);
            var basketItem = new BasketItem(1, shopItem);
            var basket = new Basket {Items = new[] {basketItem}};
            var clone = basket.Clone();

            clone.Items[0].Product.Price = 200;

            basket.Items[0].Product.Price.Should().Be(100);
            clone.Items[0].Product.Price.Should().Be(200);
        }
    }
}