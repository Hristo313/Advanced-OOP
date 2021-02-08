using System;
using System.Collections.Generic;
using System.Text;

namespace _8.CarSalesman
{
	public class Car
	{
		private string model;
		private Engine engine;
		private double? weight;
		private string color;

		public Car(string model, Engine engine)
		{
			this.Model = model;
			this.Engine = engine;
		}

		public Car(string model, Engine engine, double weight)
			: this(model, engine)
		{
			this.Weight = weight;
		}

		public Car(string model, Engine engine, string color)
			: this(model, engine)
		{
			this.Color = color;
		}

		public Car(string model, Engine engine, double weight, string color)
			: this(model, engine)
		{
			this.Weight = weight;
			this.Color = color;
		}

		public string Model { get; set; }

		public Engine Engine { get; set; }

		public double? Weight { get; set; }

		public string Color { get; set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			string weightStr = this.Weight.HasValue ?
				this.Weight.ToString() : "n/a";
			string colorStr = String.IsNullOrEmpty(this.Color) ?
				"n/a" : this.Color;
			sb
				.AppendLine($"{this.Model}:")
				.AppendLine($"  {this.Engine}")
				.AppendLine($"  Weight: {weightStr}")
				.AppendLine($"  Color: {colorStr}");

			return sb.ToString().TrimEnd();
		}
	}
}
