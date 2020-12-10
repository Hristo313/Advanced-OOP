using System;
using System.Collections.Generic;
using System.Text;

namespace _5.Reastaurant.Foods.Desserts
{
	public class Cake : Dessert
	{
		private const double GRAMS = 250;
		private const double CALORIES = 1000;
		private const decimal CAKE_PRICE = 5m;

		public Cake(string name)
			: base(name, CAKE_PRICE, GRAMS, CALORIES)
		{
		}
	}
}
