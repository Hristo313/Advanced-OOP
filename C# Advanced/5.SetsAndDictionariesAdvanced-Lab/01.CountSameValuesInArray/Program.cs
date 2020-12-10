using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValuesInArray
{
	class Program
	{
		static void Main(string[] args)
		{
			double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

			Dictionary<double, int> count = new Dictionary<double, int>();

			foreach (var number in numbers)
			{
				if (!count.ContainsKey(number))
				{
					count[number] = 0;
				}

				count[number]++;
			}

			foreach (var number in count)
			{
				Console.WriteLine($"{number.Key} - {number.Value} times");
			}
		}
	}
}
