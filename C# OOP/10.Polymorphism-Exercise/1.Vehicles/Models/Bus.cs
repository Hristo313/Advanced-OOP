using _1.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Models
{
	public class Bus : Vehicle
	{
		private const double FUEL_CONSUMPTION_INCREMENT = 1.4;

		public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
			: base(fuelQuantity, fuelConsumption + FUEL_CONSUMPTION_INCREMENT, tankCapacity)
		{
		}

		public string DriveEmpty(double kilometers)
		{
			this.FuelConsumption -= FUEL_CONSUMPTION_INCREMENT;

			return base.Drive(kilometers);
		}
	}
}
