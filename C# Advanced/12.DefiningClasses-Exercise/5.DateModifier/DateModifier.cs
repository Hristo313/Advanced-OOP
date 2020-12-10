using System;
using System.Collections.Generic;
using System.Text;

namespace _5.DateModifier
{
	public static class DateModifier
	{
		public static double GetDifferenceInDateBetweenTwoDates(string firstDate, string secondDate)
		{
			DateTime startDate = DateTime.Parse(firstDate);
			DateTime endDate = DateTime.Parse(secondDate);

			double result = (endDate - startDate).TotalDays;

			double absoluteValue = Math.Abs(result);

			return absoluteValue;
		}
	}
}
