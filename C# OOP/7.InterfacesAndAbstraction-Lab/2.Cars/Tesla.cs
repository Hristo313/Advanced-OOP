using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Cars
{
	public class Tesla : Car, IElectricCar
	{
		public Tesla(string model, string color, int battery)
			: base(model, color)
		{
			this.Battery = battery;
		}				

		public int Battery { get; set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb
				.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries")
				.AppendLine("Engine start")
				.AppendLine("Breaaak!");

			return sb.ToString().TrimEnd();
		}
	}
}
