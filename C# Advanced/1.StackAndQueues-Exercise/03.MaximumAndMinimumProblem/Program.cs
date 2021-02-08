using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaximumAndMinimumProblem
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			Stack<int> numbers = new Stack<int>();

			for (int i = 0; i < n; i++)
			{
				string[] arguments = Console.ReadLine()
					.Split()
					.ToArray();

				string type = arguments[0];

				if (type == "1")
				{
					int element = int.Parse(arguments[1]);
					numbers.Push(element);
				}
				else if (type == "2")
				{
					if (numbers.Any())
					{
						numbers.Pop();
					}
				}
				else if (type == "3")
				{
					if (numbers.Any())
					{
						Console.WriteLine(numbers.Max());
					}
				}
				else if (type == "4")
				{
					if (numbers.Any())
					{
						Console.WriteLine(numbers.Min());
					}
				}
			}

			Console.WriteLine(string.Join(", ", numbers));
		}
	}
}
