using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _6.SpeedRacing
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			//2
			//AudiA4 23 0,3
			//BMWM2 45 0,42
			//Drive BMWM2 56
			//Drive AudiA4 5
			//Drive AudiA4 13
			//End

			int numberOfCars = int.Parse(Console.ReadLine());

			List<Car> cars = new List<Car>();

			for (int i = 0; i < numberOfCars; i++)
			{
				string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

				string model = line[0];
				double fuelAmount = double.Parse(line[1]);
				double fuelConsumption = double.Parse(line[2]);

				Car car = new Car(model, fuelAmount, fuelConsumption);
				cars.Add(car);
			}

			while (true)
			{
				string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string command = line[0];

				if (command == "End")
				{
					break;
				}

				string carModel = line[1];
				double amount = double.Parse(line[2]);
	
				Car currentCar = cars.FirstOrDefault(c => c.Model == carModel);

				if (!currentCar.CanMove(amount))
				{
					Console.WriteLine("Insufficient fuel for the drive");
				}			
			}

			Console.WriteLine(string.Join(Environment.NewLine, cars));
		}
	}
}
