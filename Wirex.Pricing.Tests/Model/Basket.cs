using System.Collections.Generic;
using System.Linq;
using Wirex.Pricing.Tests.Contract;

namespace Wirex.Pricing.Tests.Model
{
    public class Basket: ICloneable<Basket>
    {   
        public IList<BasketItem> Items { get; set; } = new List<BasketItem>();
        public Basket Clone()
        {
            return new Basket {Items = Items.Select(x => x.Clone()).ToList()};
        }
    }
}