using System;
namespace _2.GenericBoxOfInteger
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int numberOfStrings = int.Parse(Console.ReadLine());

			for (int i = 0; i < numberOfStrings; i++)
			{
				int number = int.Parse(Console.ReadLine());

				Box<int> box = new Box<int>(number);
				Console.WriteLine(box);
			}
		}
	}
}
