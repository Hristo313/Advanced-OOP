using System;

namespace _3.GenericScale
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			var result = new EqualityScale<int>(5, 5);

			Console.WriteLine(result.AreEqual());			
		}
	}
}
