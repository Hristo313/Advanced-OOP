using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _03.PeriodicTable
{
	class Program
	{
		static void Main(string[] args)
		{
			int numberOfElements = int.Parse(Console.ReadLine());

			var elements = new SortedSet<string>();

			for (int i = 0; i < numberOfElements; i++)
			{
				string[] line = Console.ReadLine().Split();

				foreach (var element in line)
				{
					elements.Add(element);
				}

				//string elementsLine = Console.ReadLine();
				//int countElements = 1;

				//foreach (var element in elementsLine)
				//{
				//	if (element == ' ')
				//	{
				//		countElements++;
				//	}
				//}

				//for (int j = 0; j < countElements; j++)
				//{
				//	if (j == countElements - 1)
				//	{
				//		elements.Add(elementsLine);
				//		break;
				//	}

				//	int lastIndexOfElement = elementsLine.IndexOf(' ');
				//	string element = elementsLine.Substring(0, lastIndexOfElement);
				//	elements.Add(element);
				//	elementsLine = elementsLine.Remove(0, lastIndexOfElement + 1);
				//}
			}

			foreach (var element in elements)
			{
				Console.Write(element + " ");
			}
		}
	}
}
