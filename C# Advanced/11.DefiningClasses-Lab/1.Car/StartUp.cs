using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarManufacturer
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Tire> tires = new List<Tire>();
			List<Engine> engines = new List<Engine>();
			List<Car> cars = new List<Car>();

			while (true)
			{
				string[] tireInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

				if (tireInfo[0] == "No")
				{
					break;
				}

				Tire tire = new Tire();

				for (int i = 0; i < tireInfo.Length; i += 2)
				{
					int year = int.Parse(tireInfo[i]);
					double pressure = double.Parse(tireInfo[i + 1]);

					
					tire.Pressure += pressure;		
				}

				tires.Add(tire);
			}

			while (true)
			{
				string[] engineInfo = Console.ReadLine().Split();

				if (engineInfo[0] == "Engines")
				{
					break;
				}

				int horsePower = int.Parse(engineInfo[0]);
				double cubicCapacity = double.Parse(engineInfo[1]);

				Engine engine = new Engine(horsePower);
				engines.Add(engine);
			}

			while (true)
			{
				string[] carInfo = Console.ReadLine().Split();

				if (carInfo[0] == "Show")
				{
					break;
				}

				for (int i = 0; i < carInfo.Length; i += 7)
				{
					string mark = carInfo[i];
					string model = carInfo[i + 1];
					int year = int.Parse(carInfo[i + 2]);
					int fuelQuantity = int.Parse(carInfo[i + 3]);
					int fuelConsumption = int.Parse(carInfo[i + 4]);
					Engine engine = engines[int.Parse(carInfo[i + 5])];
					var tire = tires[int.Parse(carInfo[i + 6])];

					Car car = new Car(mark, model, year, fuelQuantity, fuelConsumption, engine, tire);
					cars.Add(car);
				}
			}

			for (int i = 0; i < cars.Count; i++)
			{
				Car car = cars[i];

				if (car.Year >= 2017 &&
					car.Engine.HorsePower > 330 &&
					car.Tire.Pressure >= 9 && car.Tire.Pressure <= 10)
				{
					car.Drive(20);
					Console.WriteLine(car);
				}
				//2 2,6 3 1,6 2 3,6 3 1,6
				//1 3,3 2 1,6 5 2,4 1 3,2
				//No more tires
				//331 2,2
				//145 2,0
				//Engines done
				//Audi A5 2017 200 12 0 0
				//BMW X5 2007 175 18 1 1
				//Show special
			}
		}
	}
}
