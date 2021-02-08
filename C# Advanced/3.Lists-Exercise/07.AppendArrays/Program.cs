using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AppendArrays
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> input = Console.ReadLine()
				.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			input.Reverse();
			var result = new List<string>();	

			foreach (var token in input)
			{
				string[] numbers = token.Split();

				foreach (var item in numbers)
				{
					if (item != "")
					{
						result.Add(item);
					}
				}
			}
			Console.WriteLine(string.Join(" ", result));
		}
	}
}