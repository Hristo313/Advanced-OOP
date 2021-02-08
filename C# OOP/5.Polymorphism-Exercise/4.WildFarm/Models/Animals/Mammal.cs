using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Models.Animals
{
	public abstract class Mammal : Animal
	{
		protected Mammal(string name, double weight, string livingRegion)
			: base(name, weight)
		{
			this.LivingRegion = livingRegion;
		}

		public string LivingRegion { get; private set; }
	}
}
