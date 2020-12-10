using System;
using System.Collections.Generic;
using System.Text;

namespace _1.RawData
{
	public class Engine
	{
		public Engine(int speed, int power)
		{
			this.Speed = speed;
			this.Power = power;
		}

		public int Speed { get; }

		public int Power { get; }
	}
}
