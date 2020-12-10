using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _5.GreedyTimes
{
	public class Bag
	{
        private readonly List<Item> bag;
        private long capacity;
        private long current;

        public Bag(long capacity)
        {
            this.capacity = capacity;
            bag = new List<Item>();
        }

        public long GoldQuantity
        {
            get
            {
                return bag.Where(i => i is Gold).Sum(i => i.Quantity);
            }
        }

        public long CashQuantity
        {
            get
            {
                return bag.Where(i => i is Cash).Sum(i => i.Quantity);
            }
        }

        public long GemQuantity
        {
            get
            {
                return bag.Where(i => i is Gem).Sum(i => i.Quantity);
            }
        }

        public void AddGoldItem(Gold item)
        {
            if (capacity >= current + item.Quantity)
            {
                var goldItems = GetGoldItems();

                if (goldItems.Any(gi => gi.Name == item.Name))
                {
                    goldItems.Single(gi => gi.Name == item.Name).IncreaseValue(item.Quantity);
                }
                else
                {
                    bag.Add(item);
                }

                current += item.Quantity;
            }
        }

        public void AddGemItem(Gem item)
        {
            if (capacity >= current + item.Quantity && GoldQuantity >= GemQuantity + item.Quantity)
            {
                var gemItems = GetGemItems();

                if (gemItems.Any(gi => gi.Name == item.Name))
                {
                    gemItems.Single(gi => gi.Name == item.Name).IncreaseValue(item.Quantity);
                }
                else
                {
                    bag.Add(item);
                }
                current += item.Quantity;
            }
        }

        public void AddCashItem(Cash item)
        {
            if (capacity >= current + item.Quantity && GemQuantity >= CashQuantity + item.Quantity)
            {
                var cashItems = GetCashItems();

                if (cashItems.Any(gi => gi.Name == item.Name))
                {
                    cashItems.Single(gi => gi.Name == item.Name).IncreaseValue(item.Quantity);
                }
                else
                {
                    bag.Add(item);
                }
                current += item.Quantity;
            }
        }

        public List<Item> GetCashItems()
        {
            return bag.Where(i => i is Cash).ToList();
        }

        public List<Item> GetGoldItems()
        {
            return bag.Where(i => i is Gold).ToList();
        }

        public List<Item> GetGemItems()
        {
            return bag.Where(i => i is Gem).ToList();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            var dictionary = bag.GroupBy(i => i.GetType().Name).ToDictionary(g => g.Key, g => g.ToList());

            foreach (var kvp in dictionary.OrderByDescending(kv => kv.Value.Sum(i => i.Quantity)))
            {
                if (kvp.Key == "Cash")
                {
                    builder.AppendLine($"<Cash> ${kvp.Value.Sum(i => i.Quantity)}");
                }
                else if (kvp.Key == "Gem")
                {
                    builder.AppendLine($"<Gem> ${kvp.Value.Sum(i => i.Quantity)}");
                }
                else if (kvp.Key == "Gold")
                {
                    builder.AppendLine($"<Gold> ${kvp.Value.Sum(i => i.Quantity)}");
                }

                foreach (var item in kvp.Value.OrderByDescending(i => i.Name).ThenBy(i => i.Quantity))
                {
                    builder.AppendLine($"##{item.Name} - {item.Quantity}");
                }
            }

            return builder.ToString().TrimEnd();
        }
    }
}
