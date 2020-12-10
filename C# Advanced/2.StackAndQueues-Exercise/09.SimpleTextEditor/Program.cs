using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _09.SimpleTextEditor
{
	class Program
	{
		static void Main(string[] args)
		{
			int numbersOfOperations = int.Parse(Console.ReadLine());
			Stack<string> versions = new Stack<string>();
			string text = "";

			for (int i = 0; i < numbersOfOperations; i++)
			{
				string[] line = Console.ReadLine().Split();
				string command = line[0];

				switch (command)
				{
					case "1":
						versions.Push(text);
						string someString = line[1];
						text += someString;
						break;

					case "2":
						versions.Push(text);
						int count = int.Parse(line[1]);
						text = text.Remove(text.Length - count, count);
						break;

					case "3":
						int index = int.Parse(line[1]);
						Console.WriteLine(text[index - 1]);
						break;

					case "4":
						text = "";
						text += versions.Pop();
						break;

					default:
						break;
				}
			}

		}
	}
}
