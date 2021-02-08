using System;
using System.Linq;

namespace _05.MultiplyBigNumber
{
	class Program
	{
		static void Main(string[] args)
		{
			string firstNumber = Console.ReadLine().TrimStart('0');
			int secondNumber = int.Parse(Console.ReadLine());

			string resultNumber = string.Empty;
			int onMind = 0;

			string reversedFirstNumber = string.Join("", firstNumber.ToCharArray().Reverse());

			if (firstNumber == "0" || secondNumber == 0)
			{
				Console.WriteLine(0);
				return;
			}

			for (int i = 0; i < reversedFirstNumber.Length; i++)
			{
				int firstDigit = int.Parse(reversedFirstNumber[i].ToString());// prevrushtame string v int

				int result = firstDigit * secondNumber + onMind;

				resultNumber += result % 10;
				onMind = result / 10;

				if (i == reversedFirstNumber.Length - 1 && onMind != 0)
				{
					resultNumber += onMind;
				}
			}
			string finalResult = string.Join("", resultNumber.ToCharArray().Reverse());
			Console.WriteLine(finalResult);
		}
	}
}