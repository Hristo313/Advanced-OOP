using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SumofCoins
{
	public class GreedyAlgorithm
	{
		public static void Main(string[] args)
		{
			var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
			var targetSum = 923;

			var selectedCoins = ChooseCoins(availableCoins, targetSum);

			Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
			foreach (var selectedCoin in selectedCoins)
			{
				Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
			}
		}

		public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
		{
			var result = new Dictionary<int, int>();
			var sortedCoins = coins.OrderByDescending(c => c).ToList();

			for (int currentCoinIndex = 0; currentCoinIndex < sortedCoins.Count; currentCoinIndex++)
			{
				var currentCoin = sortedCoins[currentCoinIndex];
				var totalCurrentCoins = targetSum / currentCoin;
				targetSum %= currentCoin;

				result[currentCoin] = totalCurrentCoins;
			}

			return result;
		}
	}
}
