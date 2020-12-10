using System;
using System.Diagnostics.Tracing;
using System.IO;

namespace _04.MergeFiles
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input1 = File.ReadAllLines("input1.txt");
			string[] input2 = File.ReadAllLines("input2.txt");

			using var writer = new StreamWriter("output.txt");

			int counter = 0;

			if (input1.Length > input2.Length)
			{
				for (int i = 0; i < input2.Length; i++)
				{
					writer.WriteLine(input1[i]);
					writer.WriteLine(input2[i]);

					counter++;
				}
				for (int i = counter; i < input1.Length; i++)
				{
					writer.WriteLine(input1[i]);
				}
			}
			else
			{
				for (int i = 0; i < input1.Length; i++)
				{
					writer.WriteLine(input1[i]);
					writer.WriteLine(input2[i]);

					counter++;
				}

				for (int i = counter; i < input2.Length; i++)
				{
					writer.WriteLine(input2[i]);
				}
			}
		}
	}
}
