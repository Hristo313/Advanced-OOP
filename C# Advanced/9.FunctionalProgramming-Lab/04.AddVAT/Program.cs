using System;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.AddVAT
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.Select(double.Parse)
				.Select(x => x * 1.2)
				.ToList()
				.ForEach(x=>Console.WriteLine($"{x:F2}"));
		}
	}
}
