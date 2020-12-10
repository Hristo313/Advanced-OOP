using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
	class Program
	{
		static void Main(string[] args)
		{
			int numberOfPumps = int.Parse(Console.ReadLine());
			Queue<int[]> pumps = new Queue<int[]>();

			FillQueue(numberOfPumps, pumps);

			int index = 0;

			for (int i = 0; i < pumps.Count; i++)
			{
				int totalAmount = 0;
				bool isCompleted = true;

				for (int j = 0; j < pumps.Count; j++)
				{
					int[] currentPump = pumps.Dequeue();
					int currentAmount = currentPump[0];
					int distance = currentPump[1];
					totalAmount += currentAmount;

					if (totalAmount < distance)
					{
						isCompleted = false;
					}
					else
					{
						totalAmount -= distance;
					}

					pumps.Enqueue(currentPump);
				}

				if (isCompleted)
				{
					index = i;
					break;
				}

				pumps.Enqueue(pumps.Dequeue());
			}

			Console.WriteLine(index);
		}

		private static void FillQueue(int numberOfPumps, Queue<int[]> pumps)
		{
			for (int i = 0; i < numberOfPumps; i++)
			{
				int[] information = Console.ReadLine().Split().Select(int.Parse).ToArray();
				pumps.Enqueue(information);
			}
		}
	}
}
