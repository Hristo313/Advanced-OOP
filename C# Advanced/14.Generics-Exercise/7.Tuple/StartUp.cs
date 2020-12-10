using System;
using System.ComponentModel.DataAnnotations;

namespace _7.Tuple
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			string[] person = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			string fullName = person[0] + " " + person[1];
			string adress = person[2];

			string[] biersPerPerson = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);
			string name = biersPerPerson[0];
			int biers = int.Parse(biersPerPerson[1]);

			string[] numbers = Console.ReadLine()
				.Split(" ", StringSplitOptions.RemoveEmptyEntries);

			int firstNumber = int.Parse(numbers[0]);
			double secondNumber = double.Parse(numbers[1]);

			var firstTuple = new MyTuple<string, string>(fullName, adress);
			var secondTuple = new MyTuple<string, int>(name, biers);
			var thirdTuple = new MyTuple<int, double>(firstNumber, secondNumber);

			Console.WriteLine(firstTuple);
			Console.WriteLine(secondTuple);
			Console.WriteLine(thirdTuple);
		}
	}
}
