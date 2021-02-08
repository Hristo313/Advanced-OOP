using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ListOfPredicates
{
	class Program
	{
		static void Main(string[] args)
		{
			int range = int.Parse(Console.ReadLine());

			int[] numbers = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			List<int> list = new List<int>();

			for (int i = 1; i <= range; i++)
			{
				bool isValidNumber = true;

				for (int j = 0; j < numbers.Length; j++)
				{
					int currentNumber = numbers[j];

					Predicate<int> predicate = i % currentNumber == 0 ?
										new Predicate<int>(n => 2 > 1) :
										new Predicate<int>(n => 2 > 3);

					if (!predicate(i))
					{
						isValidNumber = false;
						break;
					}
				}

				if (isValidNumber)
				{
					list.Add(i);
				}			
			}

			Console.WriteLine(string.Join(" ", list));
		}
	}
}
