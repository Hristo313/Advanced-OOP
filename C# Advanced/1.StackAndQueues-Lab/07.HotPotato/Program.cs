using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] names = Console.ReadLine().Split();
			int toss = int.Parse(Console.ReadLine());

			Queue<string> queue = new Queue<string>(names);

			int currentIndex = 1;

			while (queue.Count > 1)
			{
				string currentName = queue.Dequeue();

				if (currentIndex == toss)
				{
					Console.WriteLine($"Removed {currentName}");
					currentIndex = 0;
				}
				else
				{
					queue.Enqueue(currentName);
				}

				currentIndex++;
			}

			Console.WriteLine($"Last is {queue.Dequeue()}");
		}
	}
}
