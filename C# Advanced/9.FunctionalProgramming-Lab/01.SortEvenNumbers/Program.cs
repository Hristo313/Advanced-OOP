using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SortEvenNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.Where(x => x % 2 == 0)
				.OrderBy(x => x)
				.ToArray();

			string result = string.Join(", ", numbers);
			Console.WriteLine(result);
		}
	}
}
