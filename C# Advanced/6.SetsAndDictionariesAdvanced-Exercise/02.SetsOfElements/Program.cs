using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _02.SetsOfElements
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine().
				Split(" ", StringSplitOptions.RemoveEmptyEntries).
				Select(int.Parse).
				ToArray();

			int firstSet = numbers[0];
			int secondSet = numbers[1];

			var firstSetOfNumbers = new HashSet<int>();
			var secondSetOfNumbers = new HashSet<int>();

			for (int i = 0; i < firstSet + secondSet; i++)
			{
				int number = int.Parse(Console.ReadLine());

				if (i < firstSet)
				{
					firstSetOfNumbers.Add(number);
				}
				else
				{
					secondSetOfNumbers.Add(number);
				}
			}

			foreach (var number in firstSetOfNumbers)
			{
				if (secondSetOfNumbers.Contains(number))
				{
					Console.Write(number + " ");
				}
			}
		}
	}
}
