using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _10.RadioactiveMutantVampireBunnies
{
	class Program
	{
		static char[,] matrix;
		static int playerRow;
		static int playerCol;
		static bool isDead;
		static void Main(string[] args)
		{
			isDead = false;

			int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];

			matrix = new char[rows, colums];
			EnterMatrix();

			string directions = Console.ReadLine();

			foreach (var currentDirection in directions)
			{
				switch (currentDirection)
				{
					case 'L':
						Move(0, -1);
						break;

					case 'R':
						Move(0, 1);
						break;

					case 'U':
						Move(-1, 0);
						break;

					case 'D':
						Move(1, 0);
						break;

					default:
						break;
				}

				Spread();

				if (isDead)
				{
					Print();
					Console.WriteLine($"dead: {playerRow} {playerCol}");
					Environment.Exit(0);
				}
			}

			Console.WriteLine($"won: {playerRow} {playerCol}");
		}

		private static void Spread()
		{
			List<int> bunniesCoordinates = new List<int>();

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (matrix[row, col] == 'B')
					{
						bunniesCoordinates.Add(row);
						bunniesCoordinates.Add(col);
					}
				}
			}

			for (int i = 0; i < bunniesCoordinates.Count; i += 2)
			{
				int bunyRow = bunniesCoordinates[i];
				int bunyCol = bunniesCoordinates[i + 1];

				//Right
				if (isInside(bunyRow, bunyCol + 1))
				{
					if (matrix[bunyRow, bunyCol + 1] == 'P')
					{
						isDead = true;
					}
					matrix[bunyRow, bunyCol + 1] = 'B';
				}

				//Left
				if (isInside(bunyRow, bunyCol - 1))
				{
					if (matrix[bunyRow, bunyCol - 1] == 'P')
					{
						isDead = true;
					}
					matrix[bunyRow, bunyCol - 1] = 'B';
				}

				//Down
				if (isInside(bunyRow - 1, bunyCol))
				{
					if (matrix[bunyRow - 1, bunyCol] == 'P')
					{
						isDead = true;
					}
					matrix[bunyRow - 1, bunyCol] = 'B';
				}

				//Up
				if (isInside(bunyRow + 1, bunyCol))
				{
					if (matrix[bunyRow + 1, bunyCol] == 'P')
					{
						isDead = true;
					}
					matrix[bunyRow + 1, bunyCol] = 'B';
				}
			}
		}

		private static void Move(int row, int col)
		{
			if (!isInside(playerRow + row, playerCol + col))
			{
				matrix[playerRow, playerCol] = '.';
				Spread();
				Print();
				Console.WriteLine($"won: {playerRow} {playerCol}");
				Environment.Exit(0);
			}

			if (matrix[playerRow + row, playerCol + col] == 'B')
			{
				Spread();
				Print();
				Console.WriteLine($"dead: {playerRow + row} {playerCol + col}");
				Environment.Exit(0);
			}

			matrix[playerRow, playerCol] = '.';
			playerRow += row;
			playerCol += col;
			matrix[playerRow, playerCol] = 'P';
		}

		private static void Print()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.Write(matrix[row, col]);
				}
				Console.WriteLine();
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

					if (matrix[row, col] == 'P')
					{
						playerRow = row;
						playerCol = col;
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
