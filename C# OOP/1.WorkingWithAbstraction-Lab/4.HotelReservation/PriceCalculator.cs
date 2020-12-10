using System;
using System.Collections.Generic;
using System.Text;

namespace _4.HotelReservation
{
	public static class PriceCalculator
	{
		public static decimal Calculate(decimal pricePerDay, int days, Season season, Discount discount)
		{
			decimal priceBeforeDiscount = days * pricePerDay * (int)season;
			decimal discountAmount = priceBeforeDiscount * (decimal)discount / 100;	
			decimal price = priceBeforeDiscount - discountAmount;

			return price;
		}
	}
}
