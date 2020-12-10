using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.ReadLine()
				.Split()
				.Where(word => char.IsUpper(word[0]))
				.ToList()
				.ForEach(Console.WriteLine);
		}
	}
}
