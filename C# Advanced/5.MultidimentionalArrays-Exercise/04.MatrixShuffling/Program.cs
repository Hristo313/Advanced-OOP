using System;
using System.Linq;

namespace _04.MatrixShuffling
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];
			string[,] matrix = new string[rows, colums];

			for (int row = 0; row < rows; row++)
			{
				string[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

				for (int col = 0; col < colums; col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}

			while (true)
			{
				string[] command = Console.ReadLine().Split();

				if (command[0] == "END")
				{
					break;
				}

				if (command[0] != "swap" || command.Length != 5)
				{
					Console.WriteLine("Invalid input!");
					continue;
				}

				int row1 = int.Parse(command[1]);
				int col1 = int.Parse(command[2]);
				int row2 = int.Parse(command[3]);
				int col2 = int.Parse(command[4]);

				bool isValidFirstCell = isValidCell(matrix, row1, col1);
				bool isValidSecondCell = isValidCell(matrix, row2, col2);

				if (isValidFirstCell && isValidSecondCell)
				{
					string currentMatrix = matrix[row1, col1];
					matrix[row1, col1] = matrix[row2, col2];
					matrix[row2, col2] = currentMatrix;

					for (int row = 0; row < rows; row++)
					{
						for (int col = 0; col < colums; col++)
						{
							if (col == colums - 1)
							{
								Console.Write(matrix[row, col]);
								break;
							}

							Console.Write(matrix[row, col] + " ");
						}

						Console.WriteLine();
					}
				}
				else
				{
					Console.WriteLine("Invalid input!");
				}
			}
		}

		static bool isValidCell(string[,] matrix, int row, int col)
		{
			if (row >= 0 && row < matrix.GetLength(0) &&
			   col >= 0 && col < matrix.GetLength(1))
			{
				return true;
			}

			return false;
		}
	}
}
