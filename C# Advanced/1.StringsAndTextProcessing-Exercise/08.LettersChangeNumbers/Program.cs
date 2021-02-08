using System;

namespace _08.LettersChangeNumbers
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			decimal sum = 0;
			char firstLetter = '\0';
			char lastLetter = '\0';
			string currentNumber = string.Empty;
			decimal currentSum = 0;

			foreach (char symbol in text)
			{
				if (symbol == ' ')
				{
					continue;
				}

				if (char.IsLetter(symbol))
				{
					if (firstLetter == '\0')
					{
						firstLetter = symbol;
						continue;
					}

					if (lastLetter == '\0')
					{
						lastLetter = symbol;
						decimal number = decimal.Parse(currentNumber);
						int firstLetterPositionInAlphabet = GetAlphabetPosition(firstLetter);
						int lastLetterPositionInAlphabet = GetAlphabetPosition(lastLetter);

						if (char.IsLower(firstLetter))
						{
							currentSum += number * firstLetterPositionInAlphabet;
						}

						if (char.IsUpper(firstLetter))
						{
							decimal result = (number / firstLetterPositionInAlphabet);
							if ((result * 1000) % 10 == 5)
							{
								result = result + 0.001M;
							}
							currentSum += Math.Round(result, 2);
						}

						if (char.IsLower(lastLetter))
						{
							currentSum += lastLetterPositionInAlphabet;
						}

						if (char.IsUpper(lastLetter))
						{
							currentSum -= lastLetterPositionInAlphabet;
						}
						sum += currentSum;
						currentSum = 0;
						firstLetter = '\0';
						lastLetter = '\0';
						currentNumber = string.Empty;
					}
				}
				else if (char.IsDigit(symbol))
				{
					currentNumber += symbol;
				}
			}
			Console.WriteLine("{0:F2}", Math.Round(sum, 2));
		}
		private static int GetAlphabetPosition(char letter)
		{
			string currentLetter = letter.ToString();
			currentLetter = currentLetter.ToLower();
			int counter = 1;
			for (int i = 'a'; i <= 'z'; i++)
			{
				if (i == currentLetter[0])
				{
					break;
				}
				counter++;
			}
			return counter;
		}
	}
}