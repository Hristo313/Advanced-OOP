using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.GenericSwapMethodStrings
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int numberOfStrings = int.Parse(Console.ReadLine());
			List<string> names = new List<string>();

			for (int i = 0; i < numberOfStrings; i++)
			{
				string name = Console.ReadLine();
				names.Add(name);
			}

			Box<string> box = new Box<string>(names);

			int[] indexToSwap = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int firstIndex = indexToSwap[0];
			int secondIndex = indexToSwap[1];

			box.Swap(box.Values, firstIndex, secondIndex);
			Console.WriteLine(box);

		// Swap Method For Integers

			//int numberOfStrings = int.Parse(Console.ReadLine());
			//List<int> numbers = new List<int>();

			//for (int i = 0; i < numberOfStrings; i++)
			//{
			//	int number = int.Parse(Console.ReadLine());
			//	numbers.Add(number);
			//}

			//Box<int> box = new Box<int>(numbers);

			//int[] indexToSwap = Console.ReadLine()
			//	.Split()
			//	.Select(int.Parse)
			//	.ToArray();

			//int firstIndex = indexToSwap[0];
			//int secondIndex = indexToSwap[1];

			//box.Swap(box.Values, firstIndex, secondIndex);
			//Console.WriteLine(box);
		}
	}
}
