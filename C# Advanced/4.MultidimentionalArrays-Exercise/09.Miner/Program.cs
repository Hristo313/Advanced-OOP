using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;

namespace _09.Miner
{
	class Program
	{
		static char[,] matrix;
		static int minorRow;
		static int minorCol;
		static int colsCount;
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());
			string[] directions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
			matrix = new char[size, size];

			EnterMatrix();

			foreach (var currentDirection in directions)
			{
				switch (currentDirection)
				{
					case "left":
						Move(0, -1);
						break;

					case "right":
						Move(0, 1);
						break;

					case "up":
						Move(-1, 0);
						break;

					case "down":
						Move(1, 0);
						break;

					default:
						break;
				}
			}

			Console.WriteLine($"{colsCount} coals left. ({minorRow}, {minorCol})");
		}

		private static void Move(int row, int col)
		{
			if (isInside(minorRow + row, minorCol + col))
			{
				minorRow += row;
				minorCol += col;

				if (matrix[minorRow, minorCol] == 'e')
				{
					Console.WriteLine($"Game over! ({minorRow}, {minorCol})");
					Environment.Exit(0); // ends the programe without exceptions
				}
				if (matrix[minorRow, minorCol] == 'c')
				{
					colsCount--;
					matrix[minorRow, minorCol] = '*';

					if (colsCount == 0)
					{
						Console.WriteLine($"You collected all coals! ({minorRow}, {minorCol})");
						Environment.Exit(0);
					}
				}
			}
		}

		private static void EnterMatrix()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				char[] currentRow = Console.ReadLine().Replace(" ", "").ToCharArray();

				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					matrix[row, col] = currentRow[col];

					if (matrix[row, col] == 's')
					{
						minorRow = row;
						minorCol = col;
					}
					if (matrix[row, col] == 'c')
					{
						colsCount++;
					}
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
