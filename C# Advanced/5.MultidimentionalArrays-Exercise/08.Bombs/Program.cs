using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Bombs
{
	class Program
	{
		static int[,] matrix;
		static int aliveCells;
		static int sumOfCells;
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			matrix = new int[size, size];
			EnterMatrix();

			string[] coordinates = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < coordinates.Length; i++)
			{
				string[] indexes = coordinates[i].Split(',', StringSplitOptions.RemoveEmptyEntries);
				int rowIndex = int.Parse(indexes[0]);
				int colIndex = int.Parse(indexes[1]);
				int bomb = matrix[rowIndex, colIndex];

				if (isInside(rowIndex, colIndex + 1))
				{
					if (matrix[rowIndex, colIndex + 1] > 0)
					{
						matrix[rowIndex, colIndex + 1] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex, colIndex - 1))
				{
					if (matrix[rowIndex, colIndex - 1] > 0)
					{
						matrix[rowIndex, colIndex - 1] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex + 1, colIndex))
				{
					if (matrix[rowIndex + 1, colIndex] > 0)
					{
						matrix[rowIndex + 1, colIndex] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex - 1, colIndex))
				{
					if (matrix[rowIndex - 1, colIndex] > 0)
					{
						matrix[rowIndex - 1, colIndex] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex + 1, colIndex + 1))
				{
					if (matrix[rowIndex + 1, colIndex + 1] > 0)
					{
						matrix[rowIndex + 1, colIndex + 1] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex + 1, colIndex - 1))
				{
					if (matrix[rowIndex + 1, colIndex - 1] > 0)
					{
						matrix[rowIndex + 1, colIndex - 1] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex - 1, colIndex + 1))
				{
					if (matrix[rowIndex - 1, colIndex + 1] > 0)
					{
						matrix[rowIndex - 1, colIndex + 1] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}

				if (isInside(rowIndex - 1, colIndex - 1))
				{
					if (matrix[rowIndex - 1, colIndex - 1] > 0)
					{
						matrix[rowIndex - 1, colIndex - 1] -= bomb;
					}

					matrix[rowIndex, colIndex] = 0;
				}
			}

			AliveCells();
			Print();
		}

		private static void AliveCells()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (matrix[row, col] > 0)
					{
						aliveCells++;
						sumOfCells += matrix[row, col];
					}
				}
			}

			Console.WriteLine($"Alive cells: {aliveCells}");
			Console.WriteLine($"Sum: {sumOfCells}");
		}

		private static void Print()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (col == matrix.GetLength(1) - 1)
					{
						Console.Write(matrix[row, col]);
						break;
					}

					Console.Write(matrix[row, col] + " ");
				}

				Console.WriteLine();
			}
		}

		private static void EnterMatrix()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				int[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}
		}

		private static bool isInside(int row, int col)
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
