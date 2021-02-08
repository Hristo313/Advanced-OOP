using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace _02.BasicQueueOperations
{
	class Startup
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

			Queue<int> numbers = new Queue<int>(numbersToEnqueue);

			int n = input[0];
			int s = input[1];
			int x = input[2];

			DeleteFromQueue(numbers, s);

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

		private static void DeleteFromQueue(Queue<int> numbers, int s)
		{
			for (int i = 0; i < s; i++)
			{
				numbers.Dequeue();
			}
		}
	}
}
