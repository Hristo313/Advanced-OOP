using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CarManufacturer
{
	public class Car
	{
		private int year;

		public Car(string mark, string model, int year, double fuelQuantity, double fuelConsuption,
			Engine engine, Tire tire)
		{
			this.Mark = mark;
			this.Model = model;
			this.Year = year;
			this.FuelQuantity = fuelQuantity;
			this.FuelConsuption = fuelConsuption;
			this.Engine = engine;
			this.Tire = tire;
		}

		public string Mark { get; set; }

		public string Model { get; set; }

		public int Year
		{
			get
			{
				return this.year;
			}

			set
			{
				if (value < 2017)
				{

					//throw new Exception("Year can not be less than 2000!");
				}

				this.year = value;
			}
		}

		public double FuelQuantity { get; set; }

		public double FuelConsuption { get; set; }

		public Engine Engine { get; set; }

		public Tire Tire { get; set; }

		public void Drive(double distance)
		{
			var neededFuel = distance * this.FuelConsuption;
			bool canContinue = this.FuelQuantity - neededFuel >= 0;

			if (!canContinue)
			{
				//throw new Exception("Not enough fuel to perform this trip!");
			}
			else
			{
				this.FuelQuantity -= neededFuel;
			}
		}

		public override string ToString()
		{
			return $"Make: {this.Mark}" + Environment.NewLine +
				  $"Model: {this.Model}" + Environment.NewLine +
				  $"Year: {this.Year}" + Environment.NewLine +
				  $"HorsePowers: {this.Engine.HorsePower}" + Environment.NewLine +
				  $"Fuel: { this.FuelQuantity:F1}";
		}
	}
}