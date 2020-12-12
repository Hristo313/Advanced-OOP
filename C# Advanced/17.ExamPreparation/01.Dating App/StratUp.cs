using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Dating_App
{
	public class StratUp
	{
		public static void Main(string[] args)
		{
			int[] malesInput = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] femalesInput = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			Stack<int> males = new Stack<int>(malesInput);
			Queue<int> females = new Queue<int>(femalesInput);

			int matches = 0;

			while (females.Count > 0 && males.Count > 0)
			{
				int currentMales = males.Peek();
				int currentFemales = females.Peek();

				if (currentFemales <= 0)
				{
					females.Dequeue();				
					continue;
				}

				if (currentMales <= 0)
				{
					males.Pop();
					continue;
				}

				if (currentFemales % 25 == 0)
				{
					females.Dequeue();

					if (females.Count > 0)
					{
						females.Dequeue();
					}

					continue;
				}

				if (currentMales % 25 == 0)
				{
					males.Pop();

					if (males.Count > 0)
					{
						males.Pop();
					}

					continue;
				}

				if (currentFemales == currentMales)
				{
					matches++;
					males.Pop();
					females.Dequeue();
				}
				else
				{
					females.Dequeue();
					males.Pop();
					males.Push(currentMales -= 2);				
				}
			}

			Console.WriteLine($"Matches: {matches}");

			if (males.Any())
			{
				Console.WriteLine($"Males left: {string.Join(", ", males)}");
			}
			else
			{
				Console.WriteLine("Males left: none");
			}

			if (females.Any())
			{
				Console.WriteLine($"Females left: {string.Join(", ", females)}");
			}
			else
			{
				Console.WriteLine("Females left: none");
			}
		}
	}
}
