using System;
using System.Collections.Generic;

namespace _05.CountSymbols
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();

			var symbols = new SortedDictionary<char, int>();

			for (int i = 0; i < text.Length; i++)
			{
				char symbol = text[i];

				if (!symbols.ContainsKey(symbol))
				{
					symbols[symbol] = 0;
				}

				symbols[symbol]++;
			}

			foreach (var kvp in symbols)
			{
				char symbol = kvp.Key;
				int count = kvp.Value;

				Console.WriteLine($"{symbol}: {count} time/s");
			}
		}
	}
}
