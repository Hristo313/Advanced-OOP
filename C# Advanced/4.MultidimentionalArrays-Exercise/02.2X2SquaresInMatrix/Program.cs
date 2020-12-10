using System;
using System.Linq;

namespace _02._2X2SquaresInMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split().Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];
			string[,] matrix = new string[rows, colums];

			for (int row = 0; row < rows; row++)
			{
				string[] currentRow = Console.ReadLine().Split();

				for (int col = 0; col < colums; col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}

			int countSquere = 0;

			for (int row = 0; row < rows - 1; row++)
			{
				for (int col = 0; col < colums - 1; col++)
				{
					if (matrix[row, col] == matrix[row, col + 1] &&
						matrix[row, col] == matrix[row + 1, col] &&
						matrix[row, col] == matrix[row + 1, col + 1])
					{
						countSquere++;
					}
				}
			}

			Console.WriteLine(countSquere);
		}
	}
}
