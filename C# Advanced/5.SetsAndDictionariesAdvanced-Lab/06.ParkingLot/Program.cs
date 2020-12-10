using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
	class Program
	{
		static void Main(string[] args)
		{
			var parking = new HashSet<string>();

			while (true)
			{
				string[] line = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

				if (line[0] == "END")
				{
					break;
				}

				string direction = line[0];
				string carNUmber = line[1];

				if (direction == "IN")
				{
					parking.Add(carNUmber);
				}
				else
				{
					parking.Remove(carNUmber);
				}
			}

			if (parking.Any())
			{
				foreach (var car in parking)
				{
					Console.WriteLine(car);
				}
			}
			else
			{
				Console.WriteLine("Parking Lot is Empty");
			}

		}
	}
}
