using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Models
{
	public class Car : Vehicle
	{
		private const double FUEL_CONSUMPTION_INCREMENT = 0.9;

		public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
			: base(fuelQuantity, fuelConsumption, tankCapacity)
		{
		}

		public override double FuelConsumption
		{
			get
			{
				return base.FuelConsumption;
			}
			protected set
			{
				base.FuelConsumption = value + FUEL_CONSUMPTION_INCREMENT;
			}
		}
	}
}
