using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _08.TrafficJam
{
	class Program
	{
		static void Main(string[] args)
		{
			int passingCars = int.Parse(Console.ReadLine());
			Queue<string> cars = new Queue<string>();

			int carsPassed = 0;

			while (true)
			{
				string command = Console.ReadLine();

				if (command == "end")
				{
					break;
				}
				else if (command == "green")
				{
					for (int i = 0; i < passingCars; i++)
					{
						if (cars.Any())
						{
							Console.WriteLine($"{cars.Dequeue()} passed!");
							carsPassed++;
						}
					}
				}
				else
				{
					cars.Enqueue(command);
				}
			}

			Console.WriteLine($"{carsPassed} cars passed the crossroads.");
		}
	}
}
