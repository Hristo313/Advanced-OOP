using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.SpeedRacing
{
	public class Car
	{
		public Car(string model, double fuelAmount, double fuelConsumption)
		{
			this.Model = model;
			this.FuelAmount = fuelAmount;
			this.FuelConsumptionPerKilometer = fuelConsumption;
			this.TravelledDistance = 0;
		}

		public string Model { get; set; }

		public double FuelAmount { get; set; }

		public double FuelConsumptionPerKilometer { get; set; }

		public double TravelledDistance { get; set; }

		public override string ToString()
		{
			return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
		}
		public bool CanMove(double amount)
		{
			double neededFuel = amount * FuelConsumptionPerKilometer;

			if(amount >= neededFuel)
			{
				FuelAmount -= neededFuel;
				TravelledDistance += amount;
				return true;
			}

			return false;
		}
	}
}
