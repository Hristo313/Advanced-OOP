using _1.Vehicles.Common;
using _1.Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Factories
{
	public class Vehiclefactory
	{
		public Vehicle ProduceVehicle(string type, double fuelQuantity, double fuelConsumption, double tankCapacity)
		{
			Vehicle vehicle = null;

			if(type == "Car")
			{
				vehicle = new Car(fuelQuantity, fuelConsumption, tankCapacity);
			}
			else if(type == "Truck")
			{
				vehicle = new Truck(fuelQuantity, fuelConsumption, tankCapacity);
			}
			else if (type == "Bus")
			{
				vehicle = new Bus(fuelQuantity, fuelConsumption, tankCapacity);
			}

			if (vehicle == null)
			{
				throw new ArgumentException(ExceptionMessages.InvalidTypeExceptionMessage);
			}

			return vehicle;
		}
	}
}
