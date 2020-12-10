using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Vehicles.Common
{
	public static class ExceptionMessages
	{
		public static string NotEnoughFuelExceptionMessage = "{0} needs refueling";

		public static string InvalidTypeExceptionMessage = "Invalid vehicle type!";

		public static string FuelIsAboveTheCapacity = "Cannot fit {0} fuel in the tank";

		public static string NegativeFuel = "Fuel must be a positive number";
	}
}
