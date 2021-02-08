using System;
using System.Linq;

namespace _12.TriFunction
{
	class Program
	{
		static void Main(string[] args)
		{
			int sum = int.Parse(Console.ReadLine());

			string[] people = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			Func<string, int, bool> isInRange = (name, range)
				=> name.Sum(x => x) >= range;

			Func<string[], Func<string, int, bool>, string> myFunc = (names, isInRange)
				=> names.FirstOrDefault(x => isInRange(x, sum));

			string currentName = myFunc(people, isInRange);

			Console.WriteLine(currentName);
		}
	}
}
