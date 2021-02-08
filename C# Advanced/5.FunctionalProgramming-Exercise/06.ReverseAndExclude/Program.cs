using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _06.ReverseAndExclude
{
	class Program
	{
		static void Main(string[] args)
		{
			var numbers = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToList();

			int devide = int.Parse(Console.ReadLine());

			for (int i = 0; i < numbers.Count; i++)
			{
				int currentNumber = numbers[i];

				Predicate<int> predicate = currentNumber % devide == 0 ?
					new Predicate<int>(n => 2 > 1) :
					new Predicate<int>(n => 2 > 3);

				if (predicate(currentNumber))
				{
					numbers.Remove(currentNumber);
					i--;
				}
			}

			numbers.Reverse();

			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}
