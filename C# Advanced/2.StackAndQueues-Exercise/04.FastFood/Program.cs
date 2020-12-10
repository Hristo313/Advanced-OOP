using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _04.FastFood
{
	class Program
	{
		static void Main(string[] args)
		{
			int quantity = int.Parse(Console.ReadLine());

			int[] numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			Queue<int> orders = new Queue<int>(numbers);

			Console.WriteLine(orders.Max());

			int counter = 0;

			while (orders.Any())
			{
				int currentOrder = orders.Peek();

				if (quantity >= currentOrder)
				{
					quantity -= currentOrder;
					orders.Dequeue();
					counter++;
				}
				else
				{
					Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
					return;
				}
			}
			Console.WriteLine("Orders complete");
		}
	}
}
