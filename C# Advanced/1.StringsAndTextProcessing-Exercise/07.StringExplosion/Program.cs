using System;

namespace _07.StringExplosion
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			int strength = 0;

			for (int i = 0; i < input.Length; i++)
			{
				char symbol = input[i];
				if (symbol == '>')
				{
					strength += int.Parse(input[i + 1].ToString());
					continue;
				}
				if (strength > 0)
				{
					input = input.Remove(i, 1);
					i--;
					strength -= 1;
				}
			}
			Console.WriteLine(input);
		}
	}
}