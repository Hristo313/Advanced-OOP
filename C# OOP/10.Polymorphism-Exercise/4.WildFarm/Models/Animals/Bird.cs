using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace _4.WildFarm.Models.Animals
{
	public abstract class Bird : Animal
	{
		protected Bird(string name, double weight, double wingSize)
			: base(name, weight)
		{
			this.WingSize = wingSize;
		}

		public double WingSize { get; private set; }

		public override string ToString()
		{
			return base.ToString()
				+ $"{this.WingSize}, {this.Weight}, {this.FoodEaten}]";
		}
	}
}
