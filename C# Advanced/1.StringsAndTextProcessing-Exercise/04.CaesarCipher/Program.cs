using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CaesarCipher
{
	class Program
	{
		static void Main(string[] args)
		{
			string input = Console.ReadLine();
			List<char> chars = input.ToList();

			for (int i = 0; i < chars.Count; i++)
			{
				int symbol = chars[i];
				symbol += 3;
				Console.Write((char)symbol);
			}
		}
	}
}