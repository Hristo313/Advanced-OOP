using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.GreedyTimes
{
	public class Engine
	{
		public void Run()
		{
			long capacity = long.Parse(Console.ReadLine());

			string[] input = Console.ReadLine()
				.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

			var bag = new Bag(capacity);

			for (int i = 0; i < input.Length; i += 2)
			{
				string itemName = input[i];
				long itemQuantity = long.Parse(input[i + 1]);

				InsertItem(itemName, itemQuantity, bag);
				
			}

			Console.WriteLine(bag.ToString());
		}

		private void InsertItem(string name, long quantity, Bag bag)
		{
			if (name.Length == 3)
			{
				Cash cash = new Cash(name, quantity);
				bag.AddCashItem(cash);
			}
			else if (name.ToLower().EndsWith("gem"))
			{
				Gem gem = new Gem(name, quantity);
				bag.AddGemItem(gem);
			}
			else if (name.ToLower() == "gold")
			{
				Gold gold = new Gold(name, quantity);
				bag.AddGoldItem(gold);
			}
		}
	}
}
