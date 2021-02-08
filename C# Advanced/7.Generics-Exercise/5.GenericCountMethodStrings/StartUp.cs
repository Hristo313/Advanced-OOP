using System;
using System.Collections.Generic;

namespace _5.GenericCountMethodStrings
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int numberOfStrings = int.Parse(Console.ReadLine());
			List<string> elements = new List<string>();

			for (int i = 0; i < numberOfStrings; i++)
			{
				string element = Console.ReadLine();
				elements.Add(element);
			}

			Box<string> box = new Box<string>(elements);

			string elementToCompare = Console.ReadLine();

			int result = box.CompareElements(elements, elementToCompare);
			Console.WriteLine(result);
		}
	}
}
