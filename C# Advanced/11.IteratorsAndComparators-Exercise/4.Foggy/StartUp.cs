using System;
using System.Linq;

namespace _4.Foggy
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			int[] stones = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			Lake lake = new Lake(stones);

			Console.WriteLine(string.Join(", ", lake));
		}
	}
}
