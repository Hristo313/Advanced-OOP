using System;

namespace _2.GenericArrayCreator
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int length = int.Parse(Console.ReadLine());
			var result = ArrayCreator.Create(length, 100);

			for (int i = 0; i < length; i++)
			{
				Console.WriteLine(result[i]);
			}			
		}
	}
}
