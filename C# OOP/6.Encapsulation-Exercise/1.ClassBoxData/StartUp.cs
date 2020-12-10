using System;

namespace _1.ClassBoxData
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			double length = double.Parse(Console.ReadLine());
			double width = double.Parse(Console.ReadLine());
			double height = double.Parse(Console.ReadLine());

			try
			{
				Box box = new Box(length, width, height);

				Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
				Console.WriteLine($"Literal Surface Area - {box.LiteralSurfaceArea():F2}");
				Console.WriteLine($"Volume - {box.Volume():F2}");
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(ae.Message);
			}
		}
	}
}
