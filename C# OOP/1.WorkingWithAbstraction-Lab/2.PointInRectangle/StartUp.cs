using System;
using System.Linq;

namespace _2.PointInRectangle
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int[] coordinates = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int topLeftX = coordinates[0];
			int bottomRightY = coordinates[1];
			int topLeftY = coordinates[2];
			int bottomRightX = coordinates[3];

			Point topLeft = new Point(bottomRightY, topLeftY); //(0,3)
			Point bottomRight = new Point(bottomRightX, topLeftX); //(3,0)

			Rectangle rectangle = new Rectangle(topLeft, bottomRight);

			int number = int.Parse(Console.ReadLine());

			for (int i = 0; i < number; i++)
			{
				int[] points = Console.ReadLine().Split().Select(int.Parse).ToArray();
				int x = points[0];
				int y = points[1];

				Point point = new Point(x, y);

				if(rectangle.Contains(point))
				{
					Console.WriteLine("True");
				}
				else
				{
					Console.WriteLine("False");
				}
			}
		}
	}
}
