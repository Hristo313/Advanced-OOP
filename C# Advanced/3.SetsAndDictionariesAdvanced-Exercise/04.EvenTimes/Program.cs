using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
	class Program
	{
		static void Main(string[] args)
		{
			int countOfIntegers = int.Parse(Console.ReadLine());

			var numbers = new Dictionary<int, int>();

			for (int i = 0; i < countOfIntegers; i++)
			{
				int number = int.Parse(Console.ReadLine());

				if (!numbers.ContainsKey(number))
				{
					numbers[number] = 0;
				}

				numbers[number]++;
			}

			foreach (var kvp in numbers)
			{
				int number = kvp.Key;
				int times = kvp.Value;

				if (times % 2 == 0)
				{
					Console.Write(number);
					break;
				}
			}
		}
	}
}
