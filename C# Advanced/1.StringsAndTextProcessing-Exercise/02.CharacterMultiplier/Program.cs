using System;
using System.Linq;

namespace _02.CharacterMultiplier
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split().ToArray();

			string firstWord = input[0];
			string secondWord = input[1];
			int mutualLenght = Math.Min(firstWord.Length, secondWord.Length);
			int sum = 0;

			for (int i = 0; i < mutualLenght; i++)
			{
				sum += firstWord[i] * secondWord[i];
			}

			if (firstWord.Length > secondWord.Length)
			{
				for (int i = mutualLenght; i < firstWord.Length; i++)
				{
					sum += firstWord[i];
				}
			}
			else
			{
				for (int i = mutualLenght; i < secondWord.Length; i++)
				{
					sum += secondWord[i];
				}
			}
			Console.WriteLine(sum);
		}
	}
}