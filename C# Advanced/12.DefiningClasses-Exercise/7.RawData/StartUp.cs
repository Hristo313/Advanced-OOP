using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.RawData
{
	public class StartUp
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			HashSet<Car> cars = new HashSet<Car>();

			for (int i = 0; i < n; i++)
			{
				string[] carArg = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string model = carArg[0];
				int engineSpeed = int.Parse(carArg[1]);
				int enginePower = int.Parse(carArg[2]);
				int cargoWeight = int.Parse(carArg[3]);
				string cargoType = carArg[4];

				Engine engine = CreateEngine(engineSpeed, enginePower);
				Cargo cargo = CreateCargo(cargoWeight, cargoType);
				List<Tire> tires = new List<Tire>();

				for (int j = 5; j < carArg.Length; j += 2)
				{
					double pressure = double.Parse(carArg[j]);
					int age = int.Parse(carArg[j + 1]);

					Tire tire = CreateTire(age, pressure);
					tires.Add(tire);
				}

				Car car = new Car(model, engine, cargo, tires);
				cars.Add(car);
			}

			string command = Console.ReadLine();

			if (command == "fragile")
			{
				HashSet<Car> result = cars
					.Where(c => c.Cargo.Type == "fragile" 
					&& c.Tires.Any(t => t.Pressure < 1))
					.ToHashSet();

				Console.WriteLine(string.Join(Environment.NewLine, result));
			}
			else if (command == "flamable")
			{
				HashSet<Car> result = cars
					.Where(c => c.Cargo.Type == "flamable"
					&& c.Engine.Power > 250)
					.ToHashSet();

				Console.WriteLine(string.Join(Environment.NewLine, result));
			}
		}

		static Engine CreateEngine(int speed, int power)
		{
			return new Engine(speed, power);
		}

		static Cargo CreateCargo(int weight, string type)
		{
			return new Cargo(weight, type);
		}

		static Tire CreateTire(int age, double pressure)
		{
			return new Tire(age, pressure);
		}
	}
}
