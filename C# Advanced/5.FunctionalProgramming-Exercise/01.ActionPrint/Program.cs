using System;
using System.Linq;

namespace _01.ActionPrint
{
	class Program
	{
		static void Main(string[] args)
		{
			Action<string> names = new Action<string>((name) =>
			{
				Console.WriteLine(name);
			});

			Console.ReadLine()
				.Split()
				.ToList()
				.ForEach(names);
		}
	}
}
