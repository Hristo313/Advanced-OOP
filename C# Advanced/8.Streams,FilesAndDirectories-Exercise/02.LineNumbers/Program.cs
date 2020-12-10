using System;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
	class Program
	{
		static int countLetters = 0;
		static int countMarks = 0;
		static void Main(string[] args)
		{
			string[] lines = File.ReadAllLines("text.txt");

			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				Count(line);

				lines[i] = $"Line {i + 1}: {line} ({countLetters})({countMarks})";		
			}
			File.WriteAllLines("../../../output.txt", lines);
		}

		static void Count(string line)
		{
			countMarks = 0;
			countLetters = 0;

			for (int i = 0; i < line.Length; i++)
			{
				char symbol = line[i];

				if(Char.IsLetter(symbol))
				{
					countLetters++;
				}
				else if(Char.IsPunctuation(symbol))
				{
					countMarks++;
				}
			}	
		}
	}
}
