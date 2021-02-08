using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
	class Program
	{
		static void Main(string[] args)
		{
			int numberOfClothes = int.Parse(Console.ReadLine());

			var wardrobe = new Dictionary<string, Dictionary<string, int>>();

			for (int i = 0; i < numberOfClothes; i++)
			{
				string[] line = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
				string color = line[0];
				string[] clothes = line[1].Split(",");

				if (!wardrobe.ContainsKey(color))
				{
					wardrobe[color] = new Dictionary<string, int>();
				}

				for (int j = 0; j < clothes.Length; j++)
				{
					string clothe = clothes[j];

					if (!wardrobe[color].ContainsKey(clothe))
					{
						wardrobe[color][clothe] = 0;
					}

					wardrobe[color][clothe]++;
				}
			}

			string[] searchingItem = Console.ReadLine().Split();
			string searchingColor = searchingItem[0];
			string searchingClothe = searchingItem[1];

			bool itemIsFound = false;

			foreach (var kvp in wardrobe)
			{
				string color = kvp.Key;

				if(color == searchingColor)
				{
					itemIsFound = true;
				}

				var clothes = kvp.Value;

				Console.WriteLine($"{color} clothes:");
				foreach (var kvpClothe in clothes)
				{
					string clothe = kvpClothe.Key;
					int times = kvpClothe.Value;

					if(itemIsFound && clothe == searchingItem[1])
					{
						Console.WriteLine($"* {clothe} - {times} (found!)");
					}
					else
					{
						Console.WriteLine($"* {clothe} - {times} ");
					}					
				}
			}
		}
	}
}
