using System;
using System.Linq;

namespace _02.SumMatrixColums
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
				int[] currentRow = Console.ReadLine().Split().Select(int.Parse).ToArray();

				for (int col = 0; col < colums; col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}

			for (int col = 0; col < colums; col++)
			{
				int sum = 0;

				for (int row = 0; row < rows; row++)
				{
					sum += matrix[row, col];
				}

				Console.WriteLine(sum);
			}
		}
	}
}
