using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Train
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> wagons = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			int maxPassengers = int.Parse(Console.ReadLine());

			while(true)
			{
				string input = Console.ReadLine();
				if(input == "end")
				{
					break;
				}

				string[] tokens = input.Split();

				if(tokens[0] == "Add")
				{
					int addWagon = int.Parse(tokens[1]);
					wagons.Add(addWagon);
				}

				else
				{
					int passengers = int.Parse(tokens[0]);

				     for (int i = 0; i < wagons.Count; i++)
				     {
					     if(maxPassengers >= passengers + wagons[i])
						{
							wagons[i] += passengers;
							
							break;
						}
				     }
				}
			}
			Console.WriteLine(string.Join(" ", wagons));
		}
	}
}