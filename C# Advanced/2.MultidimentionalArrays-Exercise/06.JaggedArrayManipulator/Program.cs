using System;
using System.Linq;

namespace _06.JaggedArrayManipulator
{
	class Program
	{
		static void Main(string[] args)
		{
			int rows = int.Parse(Console.ReadLine());

			double[][] jaggedArray = new double[rows][];

			for (int row = 0; row < rows; row++)
			{
				jaggedArray[row] = Console.ReadLine().Split().Select(double.Parse).ToArray();

				//double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();
				//jaggedArray[row] = new double[numbers.Length];

				//for (int col = 0; col < jaggedArray[row].Length; col++)
				//{
				//	jaggedArray[row][col] = numbers[col];
				//}
			}

			Analyze(jaggedArray);

			while (true)
			{
				string[] command = Console.ReadLine().Split();

				if (command[0] == "End")
				{
					break;
				}

				int currentRow = int.Parse(command[1]);
				int currentCol = int.Parse(command[2]);
				int value = int.Parse(command[3]);

				bool isValid = isValidCell(jaggedArray, currentRow, currentCol);

				if (isValid)
				{
					if (command[0] == "Add")
					{
						jaggedArray[currentRow][currentCol] += value;
					}
					else
					{
						jaggedArray[currentRow][currentCol] -= value;
					}
				}
				else
				{
					continue;
				}
			}

			foreach (var row in jaggedArray)
			{
				Console.WriteLine(string.Join(" ", row));
			}
		}

		private static bool isValidCell(double[][] jaggedArray, int currentRow, int currentCol)
		{
			if (currentRow >= 0 && currentRow < jaggedArray.Length &&
			   currentCol >= 0 && currentCol < jaggedArray[currentRow].Length)
			{
				return true;
			}

			return false;
		}

		private static void Analyze(double[][] jaggedArray)
		{
			for (int row = 0; row < jaggedArray.Length - 1; row++)
			{
				if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
				{
					for (int col = 0; col < jaggedArray[row].Length; col++)
					{
						jaggedArray[row][col] *= 2;
						jaggedArray[row + 1][col] *= 2;
					}
				}
				else
				{
					for (int col = 0; col < jaggedArray[row].Length; col++)
					{
						jaggedArray[row][col] /= 2;
					}
					for (int col = 0; col < jaggedArray[row + 1].Length; col++)
					{
						jaggedArray[row + 1][col] /= 2;
					}
				}
			}
		}
	}
}
