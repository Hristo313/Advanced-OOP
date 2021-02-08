using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class SingleGift : GiftBase
    {
        public SingleGift(string name, int price)
            : base(name, price)
        {
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{this.Name} with the price {this.Price}");

            return this.Price;
        }
    }
}
