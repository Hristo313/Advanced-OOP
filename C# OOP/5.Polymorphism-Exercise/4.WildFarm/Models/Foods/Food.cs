using _4.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Models.Foods
{
	public abstract class Food : IFood
	{
		protected Food(int quantity)
		{
			this.Quantity = quantity;
		}

		public int Quantity { get; private set; }
	}
}
