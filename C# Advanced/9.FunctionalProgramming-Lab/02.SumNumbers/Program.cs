using System;
using System.Linq;

namespace _02.SumNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			Func<string, int> myFunc = int.Parse;

			var numbers = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(myFunc)
				.ToArray();

			Console.WriteLine(numbers.Length);
			Console.WriteLine(numbers.Sum());
		}
	}
}
