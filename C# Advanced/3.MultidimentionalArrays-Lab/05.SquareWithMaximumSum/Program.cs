using System;
using System.Linq;

namespace _05.SquareWithMaximumSum
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];
			int[,] matrix = new int[rows, colums];

			for (int row = 0; row < rows; row++)
			{
				int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

				for (int col = 0; col < colums; col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}

			int maxSum = int.MinValue;
			int sumOfCurrentSquare = 0;
			int maxRowIndex = 0;
			int maxColIndex = 0;

			for (int row = 0; row < rows - 1; row++)
			{
				for (int col = 0; col < colums - 1; col++)
				{
					sumOfCurrentSquare = matrix[row, col]
						+ matrix[row + 1, col]
						+ matrix[row, col + 1]
						+ matrix[row + 1, col + 1];

					if (sumOfCurrentSquare > maxSum)
					{
						maxSum = sumOfCurrentSquare;
						maxRowIndex = row;
						maxColIndex = col;
					}
				}
			}

			Console.WriteLine($"{matrix[maxRowIndex, maxColIndex]} {matrix[maxRowIndex, maxColIndex + 1]}");
			Console.WriteLine($"{matrix[maxRowIndex + 1, maxColIndex]} {matrix[maxRowIndex + 1, maxColIndex + 1]}");
			Console.WriteLine(maxSum);
		}
	}
}
