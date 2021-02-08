using System;

namespace _1.GenericBoxOfString
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int numberOfStrings = int.Parse(Console.ReadLine());

			for (int i = 0; i < numberOfStrings; i++)
			{
				string text = Console.ReadLine();

				Box<string> box = new Box<string>(text);
				Console.WriteLine(box);
			}			
		}
	}
}
