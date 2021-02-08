using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private readonly ICollection<GiftBase> gifts;

        public CompositeGift(string name, int price)
            : base(name, price)
        {
            gifts = new List<GiftBase>();
        }

        public void Add(GiftBase gift)
        {
            gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            gifts.Remove(gift);
        }

        public override int CalculateTotalPrice()
        {
            int totalPrice = 0;

            //Output
            Console.WriteLine($"{this.Name} contains the following products with prices:");

            foreach (GiftBase gift in this.gifts)
            {
                totalPrice += gift.CalculateTotalPrice();
            }

            return totalPrice;
        }
    }
}
