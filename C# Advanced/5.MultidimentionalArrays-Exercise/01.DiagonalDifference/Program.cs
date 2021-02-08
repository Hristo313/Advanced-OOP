using System;
using System.Linq;

namespace _01.DiagonalDifference
{
	class Program
	{
		static void Main(string[] args)
		{
			int sizeOfSquare = int.Parse(Console.ReadLine());

			int[,] square = new int[sizeOfSquare, sizeOfSquare];

			for (int row = 0; row < sizeOfSquare; row++)
			{
				int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

				for (int col = 0; col < sizeOfSquare; col++)
				{
					square[row, col] = currentRow[col];
				}
			}

			int sumOfStartDiagonal = 0;
			int sumOfEndDiagonal = 0;

			for (int row = 0; row < sizeOfSquare; row++)
			{
				for (int col = 0; col < sizeOfSquare; col++)
				{
					if (row == col)
					{
						sumOfStartDiagonal += square[row, col];
					}
				}
			}

			for (int row = 0; row < sizeOfSquare; row++)
			{
				for (int col = 0; col < sizeOfSquare; col++)
				{
					if (row + col == sizeOfSquare - 1)
					{
						sumOfEndDiagonal += square[row, col];
					}
				}
			}

			Console.WriteLine(Math.Abs(sumOfStartDiagonal - sumOfEndDiagonal));
		}
	}
}
