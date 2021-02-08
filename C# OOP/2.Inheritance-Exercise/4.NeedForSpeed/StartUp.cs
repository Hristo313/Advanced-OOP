using System;
using System.IO;

namespace _4.NeedForSpeed
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			SportCar ferrari = new SportCar(550, 1000);
			ferrari.Drive(10);
			Console.WriteLine(ferrari.Fuel);
		}
	}
}
