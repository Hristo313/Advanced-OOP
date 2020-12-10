using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
	public class Engine
	{
		private int horsePower;

		public Engine(int horsePower)
		{
			this.HorsePower = horsePower;
		}

		public int HorsePower { get; set; }

		public double CubicCapacity { get; set; }
	}
}
