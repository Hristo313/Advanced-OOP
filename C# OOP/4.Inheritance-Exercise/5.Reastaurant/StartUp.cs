using _5.Reastaurant.Foods.Desserts;
using System;

namespace _5.Reastaurant
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Cake chocolade = new Cake("Garash");

			Console.WriteLine(chocolade.Name + " " + 
				chocolade.Calories + " " +
				chocolade.Grams + " " +
				chocolade.Price);
		}
	}
}
