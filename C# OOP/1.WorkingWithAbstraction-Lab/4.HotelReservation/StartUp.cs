using System;

namespace _4.HotelReservation
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			string[] information = Console.ReadLine().Split();

			decimal pricePerDay = decimal.Parse(information[0]);
			int numberOfDays = int.Parse(information[1]);
			Season season = Enum.Parse<Season>(information[2]);

			Discount discount;

			if (information.Length == 4)
			{
				discount = Enum.Parse<Discount>(information[3]);
		    }
			else
			{
				discount = Discount.None;
			}

		    var calculator = PriceCalculator.Calculate(pricePerDay, numberOfDays, season, discount);

			Console.WriteLine($"{calculator:F2}");
		}
	}
}
