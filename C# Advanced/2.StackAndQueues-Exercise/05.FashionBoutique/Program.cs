using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int capacity = int.Parse(Console.ReadLine());

			Stack<int> boxes = new Stack<int>(numbers);
			int sum = 0;
			int racksCounter = 1;

			//5 4 8 6 3 8 7 7 9
			while (boxes.Any())
			{
				int currentClothes = boxes.Peek();
				sum += currentClothes;

				if (sum <= capacity)
				{
					boxes.Pop();
				}
				else
				{
					sum = 0;
					if (boxes.Any())
					{
						racksCounter++;
					}
				}
			}
			Console.WriteLine(racksCounter);
		}
	}
}
