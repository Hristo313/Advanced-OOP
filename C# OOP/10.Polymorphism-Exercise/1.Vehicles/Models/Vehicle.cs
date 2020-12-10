using _1.Vehicles.Common;
using _1.Vehicles.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Models
{
	public abstract class Vehicle : IDriveable, IRefuelable
	{
		private double fuelQuantity;

		public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
		{
			this.TankCapacity = tankCapacity;
			this.FuelQuantity = fuelQuantity;
			this.FuelConsumption = fuelConsumption;			
		}

		public double FuelQuantity
		{
			get
			{
				return this.fuelQuantity;
			}
			protected set
			{
				if (value > this.TankCapacity)
				{
					this.fuelQuantity = 0;
				}
				else
				{
					this.fuelQuantity = value;
				}
			}
		}

		public virtual double FuelConsumption { get; protected set; }

		public double TankCapacity { get; private set; }

		public string Drive(double kilometers)
		{
			double fuelNeeded = kilometers * this.FuelConsumption;

			if (this.FuelQuantity < fuelNeeded)
			{
				string excMsg = string.Format
					(ExceptionMessages.NotEnoughFuelExceptionMessage, this.GetType().Name);

				throw new InvalidOperationException(excMsg);
			}

			this.FuelQuantity -= fuelNeeded;

			return $"{this.GetType().Name} travelled {kilometers} km";
		}

		public virtual void Refuel(double fuelAmount)
		{
			if (fuelAmount <= 0)
			{
				throw new ArgumentException(ExceptionMessages.NegativeFuel);
			}

			double totalFuelAmount = this.FuelQuantity + fuelAmount;

			if(totalFuelAmount > this.TankCapacity)
			{
				string excMsg = string.Format(ExceptionMessages.FuelIsAboveTheCapacity, fuelAmount);
				throw new ArgumentException(excMsg);
			}

			this.FuelQuantity += fuelAmount;
		}

		public override string ToString()
		{
			return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
		}
	}
}
