using System;
using System.IO;
using System.Linq;

namespace _01.EvenLines
{
	class Program
	{
		static void Main(string[] args)
		{
			using var reader = new StreamReader("text.txt");

			int counter = 0;

			while (true)
			{
				var line = reader.ReadLine();

				if (line == null)
				{
					break;
				}

				if (counter % 2 == 0)
				{
					for (int i = 0; i < line.Length; i++)
					{
						if (Char.IsPunctuation(line[i]) && line[i] != '\'')
						{
							line = line.Replace(line[i], '@');
						}
					}

					//line = line.Replace('-', '@');
					//line = line.Replace(',', '@');
					//line = line.Replace('.', '@');
					//line = line.Replace('?', '@');
					//line = line.Replace('!', '@');

					line = String.Join(" ", line.Split().Reverse());

					Console.WriteLine(line);
				}

				counter++;
			}
		}
	}
}
