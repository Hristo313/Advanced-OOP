using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;

namespace _02.BookWorm
{
	public class StartUp
	{
		static char[,] matrix;
		static int playerRow;
		static int playerCol;
		static string initialWord;

		public static void Main(string[] args)
		{
			initialWord = Console.ReadLine();

			int size = int.Parse(Console.ReadLine());
			matrix = new char[size, size];
			GetMatrix();

			while (true)
			{
				string command = Console.ReadLine();

				if (command == "end")
				{
					break;
				}

				switch (command)
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
				}
			}

			Console.WriteLine(initialWord);
			Print();
		}

		private static void Move(int row, int col)
		{
			if (isInside(playerRow + row, playerCol + col))
			{
				if (Char.IsLetter(matrix[playerRow + row, playerCol + col]))
				{
					initialWord += matrix[playerRow + row, playerCol + col];
				}

				matrix[playerRow, playerCol] = '-';
				playerRow += row;
				playerCol += col;
				matrix[playerRow, playerCol] = 'P';
			}
			else
			{
				if (initialWord.Length > 0)
				{
					initialWord = initialWord.Substring(0, initialWord.Length - 1);
				}
				matrix[playerRow, playerCol] = 'P';
			}
		}

		private static void GetMatrix()
		{
			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				char[] currentRow = Console.ReadLine().ToCharArray();

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
