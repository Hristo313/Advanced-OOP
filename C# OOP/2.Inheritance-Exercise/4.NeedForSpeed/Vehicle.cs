using System;
using System.Collections.Generic;
using System.Text;

namespace _4.NeedForSpeed
{
	public class Vehicle
	{
		private const double DefaultFuelConsumption = 1.25;

		public Vehicle(int horsePower, double fuel)
		{
			this.HorsePower = horsePower;
			this.Fuel = fuel;
		}

		public int HorsePower { get; set; }

		public double Fuel { get; set; }

		public virtual double FuelConsumption => DefaultFuelConsumption;

		public virtual void Drive(double kilometers)
		{
			var neededFuel = kilometers * this.FuelConsumption;
			bool canContinue = this.Fuel - neededFuel >= 0;

			if (!canContinue)
			{
				throw new Exception("Not enough fuel to perform this trip!");
			}
			else
			{
			    this.Fuel -= neededFuel;
			}
		}
	}
}
