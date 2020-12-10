using System;
using System.Collections.Generic;
using System.Text;
using _1.Vehicles.Core.Contracts;
using _1.Vehicles.Factories;
using _1.Vehicles.Models;

namespace _1.Vehicles.Core
{
	public class Engine : IEngine
	{
		private Vehiclefactory vehicleFactory;

		public Engine()
		{
			this.vehicleFactory = new Vehiclefactory();
		}

		public void Run()
		{
			Vehicle car = ProduceVehicle();
			Vehicle truck = ProduceVehicle();
			Vehicle bus = ProduceVehicle();

			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				string[] command = Console.ReadLine().Split();

				try
				{
					ProcessCommand(car, truck, bus, command);
				}
				catch (InvalidOperationException ioe)
				{
					Console.WriteLine(ioe.Message);
				}			
			}

			Console.WriteLine(car);
			Console.WriteLine(truck);
			Console.WriteLine(bus);
		}

		private static void ProcessCommand(Vehicle car, Vehicle truck, Vehicle bus, string[] command)
		{
			string type = command[0];
			string vehicle = command[1];
			double kilometers = double.Parse(command[2]);

			if (type == "Drive")
			{
				if (vehicle == "Car")
				{
					Console.WriteLine(car.Drive(kilometers)); 
				}
				else if (vehicle == "Truck")
				{
					Console.WriteLine(truck.Drive(kilometers));
				}
				else if (vehicle == "Bus")
				{
					Console.WriteLine(bus.Drive(kilometers));
				}
			}
			else if (type == "Refuel")
			{
				try
				{
					if (vehicle == "Car")
					{
						car.Refuel(kilometers);
					}
					else if (vehicle == "Truck")
					{
						truck.Refuel(kilometers);
					}
					else if (vehicle == "Bus")
					{
						bus.Refuel(kilometers);
					}
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
				}
			}
			else if (type == "DriveEmpty")
			{
				Bus currentBus = (Bus)bus;
				Console.WriteLine(currentBus.DriveEmpty(kilometers));	
			}
		}

		private Vehicle ProduceVehicle()
		{
			string[] arguments = Console.ReadLine().Split();

			string type = arguments[0];
			double fuelQuantity = double.Parse(arguments[1]);
			double fuelConsumption = double.Parse(arguments[2]);
			double tankCapacity = double.Parse(arguments[3]);

			Vehicle vehicle = this.vehicleFactory.ProduceVehicle(type, fuelQuantity, fuelConsumption, tankCapacity);

			return vehicle;
		}
	}
}
