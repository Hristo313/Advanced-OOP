using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split();

			Stack<string> result = new Stack<string>(input.Reverse());

			while (result.Count > 1)
			{
				int firstNumber = int.Parse(result.Pop());
				string operation = result.Pop();
				int secondNumber = int.Parse(result.Pop());

				int tempResult = 0;

				switch (operation)
				{
					case "+":
						tempResult = firstNumber + secondNumber;
						break;
					case "-":
						tempResult = firstNumber - secondNumber;
						break;
				}

				result.Push(tempResult.ToString());
			}

			Console.WriteLine(result.Pop());
		}
	}
}
