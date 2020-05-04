namespace Wirex.Pricing.Tests.Model
{
    public class ProductModel
    {
        public ProductModel(decimal price)
        {
            Price = price;
        }
        
        public decimal Price { get; set; }
    }
}