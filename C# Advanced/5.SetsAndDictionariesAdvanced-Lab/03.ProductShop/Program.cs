using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
	class Program
	{
		static void Main(string[] args)
		{
			var shops = new Dictionary<string, Dictionary<string, double>>();

			while (true)
			{
				string[] information = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

				if (information[0] == "Revision")
				{
					break;
				}

				string shop = information[0];
				string product = information[1];
				double price = double.Parse(information[2]);

				if (!shops.ContainsKey(shop))
				{
					shops[shop] = new Dictionary<string, double>();
				}

				//if (!shops[shop].ContainsKey(product))
				//{
				//	shops[shop][product] = 1;
				//}

				shops[shop][product] = price;
			}

			foreach (var kvp in shops.OrderBy(s => s.Key).ToDictionary(x => x.Key, x => x.Value))
			{
				var shop = kvp.Key;
				var products = kvp.Value;

				Console.WriteLine($"{shop}->");
				foreach (var productKvp in products)
				{
					var product = productKvp.Key;
					var price = productKvp.Value;

					Console.WriteLine($"Product: {product}, Price: {price:F1}");
				}
			}
		}
	}
}
