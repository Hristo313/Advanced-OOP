using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BombNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			List<int> bombProp = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			int bomb = bombProp[0];
			int power = bombProp[1];

			for (int i = 0; i < numbers.Count; i++)
			{
				int currentNumber = numbers[i];

				if (currentNumber == bomb)
				{
					int startIndex = i - power;
					int endIndex = i + power;

					if (startIndex < 0)
					{
						startIndex = 0;
					}

					if (endIndex > numbers.Count - 1)
					{
						endIndex = numbers.Count - 1;
					}

					if (startIndex > numbers.Count - 1)
					{
						continue;
					}

					if (endIndex < 0)
					{
						continue;
					}

					numbers.RemoveRange(startIndex, endIndex - startIndex + 1);
					i = startIndex - 1;
				}
			}
			int sum = numbers.Sum();
			Console.WriteLine(sum);
		}
	}
}