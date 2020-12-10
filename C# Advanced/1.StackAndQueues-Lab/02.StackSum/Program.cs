using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			Stack<int> stack = new Stack<int>(numbers);

			while (true)
			{
				string[] command = Console.ReadLine()
					.ToLower()
					.Split();

				if (command[0] == "add")
				{
					stack.Push(int.Parse(command[1]));
					stack.Push(int.Parse(command[2]));
				}
				else if (command[0] == "remove")
				{
					int elementsToRemove = int.Parse(command[1]);

					if (stack.Count >= elementsToRemove)
					{
						for (int i = 0; i < elementsToRemove; i++)
						{
							stack.Pop();
						}
					}
				}
				else
				{
					break;
				}
			}

			Console.WriteLine($"Sum: {stack.Sum()}");
		}
	}
}
