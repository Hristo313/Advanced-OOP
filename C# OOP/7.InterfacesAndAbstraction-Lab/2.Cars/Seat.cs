using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Cars
{
	public class Seat : Car
	{
		public Seat(string model, string color)
			: base(model, color)
		{		
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb
				.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}")
				.AppendLine("Engine start")
				.AppendLine("Breaaak!");

			return sb.ToString().TrimEnd();
		}
	}
}
