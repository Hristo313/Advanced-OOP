using System;
using System.Collections.Generic;
using System.Linq;

namespace ReplaceRepeatingChar
{
	class Program
	{
		static void Main(string[] args)
		{
			string text = Console.ReadLine();
			List<char> chars = text.ToList();

			for (int i = 1; i < chars.Count; i++)
			{
				if (chars[i] == chars[i - 1])
				{
					chars.RemoveAt(i);
					i--;
				}
			}
			Console.WriteLine(string.Join("", chars));
		}
	}
}