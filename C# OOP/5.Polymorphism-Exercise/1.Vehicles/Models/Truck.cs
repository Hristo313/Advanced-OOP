using _1.Vehicles.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Models
{
	public class Truck : Vehicle
	{
		private const double FUEL_CONSUMPTION_INCREMENT = 1.6;
		private const double REFUEL_EFFICIENCY_PRECENTAGE = 0.95;

		public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) 
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

		public override void Refuel(double fuelAmount)
		{
			if (fuelAmount <= 0)
			{
				throw new ArgumentException(ExceptionMessages.NegativeFuel);
			}

			double totalFuelAmount = this.FuelQuantity + fuelAmount;

			if (totalFuelAmount > this.TankCapacity)
			{
				string excMsg = string.Format(ExceptionMessages.FuelIsAboveTheCapacity, fuelAmount);
				throw new ArgumentException(excMsg);
			}

			base.Refuel(fuelAmount * REFUEL_EFFICIENCY_PRECENTAGE);
		}
	}
}
