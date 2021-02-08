using _1.Vehicles.Core;
using _1.Vehicles.Core.Contracts;
using System;

namespace _1.Vehicles
{
	public class StartUp
	{
		public static void Main()
		{
			IEngine engine = new Engine();
			engine.Run();

//			Car 30 0,04 70
//Truck 100 0,5 300
//Bus 40 0,3 150
//8
//Refuel Car -10
//Refuel Truck 0
//Refuel Car 10
//Refuel Car 300
//Drive Bus 10
//Refuel Bus 1000
//DriveEmpty Bus 100
//Refuel Truck 1000
		}
	}
}
