using System;

namespace _1.RhombusOfStars
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());

			for (int count = 1; count <= size; count++)
				PrintRow(size, count);
			for (int count = size - 1; count >= 1; count--)
				PrintRow(size, count);
		}

		public static void PrintRow(int size, int count)
		{
			for (int i = 0; i < size - count; i++)
			{
				Console.Write(" ");
			}
			for (int i = 1; i < count; i++)
			{
				Console.Write("* ");
			}
			Console.WriteLine("*");

		}
	}
}
