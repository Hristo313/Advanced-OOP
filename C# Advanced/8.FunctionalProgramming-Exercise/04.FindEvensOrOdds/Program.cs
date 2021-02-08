using System;
using System.Linq;

namespace _04.FindEvensOrOdds
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] limits = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			string typeOfNumbers = Console.ReadLine();

			Predicate<int> predicate = typeOfNumbers == "odd" ?
				new Predicate<int>(n => n % 2 != 0) :
				new Predicate<int>(n => n % 2 == 0);

			for (int i = limits[0]; i <= limits[1]; i++)
			{
				if (predicate(i))
				{
					if (i == limits[1] || i == limits[1] - 1)
					{
						Console.Write(i);
						break;
					}
					Console.Write(i + " ");
				}
			}
		}
	}
}
