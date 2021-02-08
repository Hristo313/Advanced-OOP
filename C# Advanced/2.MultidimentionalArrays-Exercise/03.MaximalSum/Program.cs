using System;
using System.Linq;

namespace _03.MaximalSum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];
			int[,] matrix = new int[rows, colums];

			for (int row = 0; row < rows; row++)
			{
				int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int col = 0; col < colums; col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}

			int rowIndex = 0;
			int colIndex = 0;
			int maxSum = int.MinValue;

			for (int row = 0; row < rows - 2; row++)
			{
				for (int col = 0; col < colums - 2; col++)
				{
					int currentSum = matrix[row, col] +
								 matrix[row, col + 1] +
								 matrix[row, col + 2] +
								 matrix[row + 1, col] +
								 matrix[row + 2, col] +
								 matrix[row + 2, col + 2] +
								 matrix[row + 1, col + 1] +
								 matrix[row + 1, col + 2] +
								 matrix[row + 2, col + 1];

					if (currentSum > maxSum)
					{
						maxSum = currentSum;
						rowIndex = row;
						colIndex = col;
					}
				}
			}

			Console.WriteLine($"Sum = {maxSum}");

			for (int row = rowIndex; row <= rowIndex + 2; row++)
			{
				for (int col = colIndex; col <= colIndex + 2; col++)
				{
					if (col == colIndex + 2)
					{
						Console.Write(matrix[row, col]);
						break;
					}
					Console.Write(matrix[row, col] + " ");
				}

				Console.WriteLine();
			}
		}
	}
}
