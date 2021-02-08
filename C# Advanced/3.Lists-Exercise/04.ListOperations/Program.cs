using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.ListOperations
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			while (true)
			{
				string lnput = Console.ReadLine();

				if (lnput == "End")
				{
					break;
				}

				string[] tokens = lnput.Split();

				if (tokens[0] == "Add")
				{
					int numberToAdd = int.Parse(tokens[1]);
					numbers.Add(numberToAdd);
				}
				else if (tokens[0] == "Insert")
				{
					int number = int.Parse(tokens[1]);
					int Index = int.Parse(tokens[2]);
					if (Index > numbers.Count || Index < 0)
					{
						Console.WriteLine("Invalid index");
						continue;
					}
					numbers.Insert(Index, number);
				}
				else if (tokens[0] == "Remove")
				{
					int Index = int.Parse(tokens[1]);
					if (Index > numbers.Count || Index < 0)
					{
						Console.WriteLine("Invalid index");
						continue;
					}
					numbers.RemoveAt(Index);
				}
				else if (tokens[0] == "Shift")
				{
					string direction = tokens[1];
					int rotations = int.Parse(tokens[2]);

					if (direction == "left")
					{
						for (int i = 0; i < rotations % numbers.Count; i++)
						{
							int firstNumber = numbers[0];

							for (int j = 0; j < numbers.Count - 1; j++)
							{
								numbers[j] = numbers[j + 1];
							}
							numbers[numbers.Count - 1] = firstNumber;
						}
					}
					else
					{
						for (int i = 0; i < rotations % numbers.Count; i++)
						{
							int lastNumber = numbers[numbers.Count - 1];

							for (int j = numbers.Count - 1; j > 0; j--)
							{
								numbers[j] = numbers[j - 1];
							}
							numbers[0] = lastNumber;
						}
					}
				}
			}
			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}