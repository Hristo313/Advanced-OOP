using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
	class Program
	{
		static void Main(string[] args)
		{
			string wordToCount = File.ReadAllText("words.txt");
			string wordInInput = File.ReadAllText("text.txt");

			string symbols = " ";

			foreach (var @char in wordInInput)
			{
				if (Char.IsPunctuation(@char) && @char != '\'')   // Take all punctoation symbols 
				{
					symbols += @char;
				}
			}

			string[] allWordsToCount = wordToCount.ToLower().Split(symbols.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			string[] allWordsInInput = wordInInput.ToLower().Split(symbols.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			// Split to all punctoation symbols to take the free words

			var words = new Dictionary<string, int>();

			for (int i = 0; i < allWordsToCount.Length; i++)
			{
				string currentWordToCount = allWordsToCount[i];

				if (!words.ContainsKey(currentWordToCount))
				{
					words[currentWordToCount] = 0;
				}

				for (int j = 0; j < allWordsInInput.Length; j++)
				{
					string currentWordInInput = allWordsInInput[j];

					if (currentWordToCount == currentWordInInput)
					{
						words[currentWordToCount]++;
					}
				}
			}

			var sortedWords = words
				.OrderByDescending(x => x.Value)
				.ToDictionary(x => x.Key, x => x.Value);

			string[] expectedReader = File.ReadAllLines("../../../expectedResult.txt");

			bool isSame = true;
			int number = 0;

			foreach (var kvp in sortedWords)
			{
				string word = kvp.Key;
				int count = kvp.Value;
				string line = $"{word} - {count}";

				if (line != expectedReader[number])
				{
					isSame = false;
					break;
				}
				number++; 
			}

			if (isSame)
			{
				Console.WriteLine("Equal");
			}

			using var writer = new StreamWriter("../../../result.txt");

			foreach (var kvp in sortedWords)
			{
				string word = kvp.Key;
				int count = kvp.Value;
				writer.WriteLine($"{word} - {count}");
			}
		}
	}
}
