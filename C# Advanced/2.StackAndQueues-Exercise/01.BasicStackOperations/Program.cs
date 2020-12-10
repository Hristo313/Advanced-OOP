using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] input = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int[] numbersToEnqueue = Console.ReadLine()
			.Split()
			.Select(int.Parse)
			.ToArray();

			Stack<int> numbers = new Stack<int>(numbersToEnqueue);

			int n = input[0];
			int s = input[1];
			int x = input[2];

			for (int i = 0; i < s; i++)
			{
				if (numbers.Any())
				{
					numbers.Pop();
				}
			}

			if (numbers.Contains(x))
			{
				Console.WriteLine("true");
			}
			else if (numbers.Any())
			{
				Console.WriteLine(numbers.Min());
			}
			else
			{
				Console.WriteLine(0);
			}
		}
	}
}
