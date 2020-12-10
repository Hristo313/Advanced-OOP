using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.AppliedArithmetics
{
	class Program
	{
		static void Main(string[] args)
		{
			Action<int[]> printer = new Action<int[]>((arr) =>
			{
				Console.WriteLine(string.Join(" ", arr));
			});

			int[] integers = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			while (true)
			{
				string input = Console.ReadLine();

				if (input == "end")
				{
					break;
				}

				if (input == "print")
				{
					printer(integers);
				}
				else
				{
					Func<int[], int[]> numbers = GetNumbers(input);

					integers = numbers(integers);
				}
			}
		}

		static Func<int[], int[]> GetNumbers(string input)
		{
			Func<int[], int[]> numbers = null;

			if (input == "add")
			{
				numbers = new Func<int[], int[]>((arr) =>
			   {
				   for (int i = 0; i < arr.Length; i++)
				   {
					   arr[i]++;
				   }
				   return arr;
			   });
			}
			else if (input == "multiply")
			{
				numbers = new Func<int[], int[]>((arr) =>
				{
					for (int i = 0; i < arr.Length; i++)
					{
						arr[i] *= 2;
					}
					return arr;
				});
			}
			else if (input == "subtract")
			{
				numbers = new Func<int[], int[]>((arr) =>
				{
					for (int i = 0; i < arr.Length; i++)
					{
						arr[i]--;
					}
					return arr;
				});
			}

			return numbers;
		}
	}
}
