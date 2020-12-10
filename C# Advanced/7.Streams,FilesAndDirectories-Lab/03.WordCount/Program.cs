using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
	class Program
	{
		static void Main(string[] args)
		{		
			string wordToCount = File.ReadAllText("words.txt");
			string wordInInput = File.ReadAllText("input.txt");			

			string symbols = " ";

			foreach (var @char in wordInInput)
			{
				if (Char.IsPunctuation(@char) && @char != '\'') // Take all punctoation symbols 
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

					if(currentWordToCount == currentWordInInput)
					{
						words[currentWordToCount]++;
					}
				}
			}

			using var writer = new StreamWriter("../../../output.txt");

			foreach (var kvp in words.OrderByDescending(x => x.Value))
			{
				string word = kvp.Key;
				int count = kvp.Value;
				writer.WriteLine($"{word} - {count}");		
			}
		}
	}
}
