using System;
using System.Data;
using System.Linq;

namespace _01.SumMatrixElements
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];
			int[,] matrix = new int[rows, colums];

			int sum = 0;

			for (int row = 0; row < rows; row++)
			{
				int[] currentRow = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

				for (int col = 0; col < colums; col++)
				{
					matrix[row, col] = currentRow[col];
					sum += currentRow[col];
				}
			}

			Console.WriteLine(rows);
			Console.WriteLine(colums);
			Console.WriteLine(sum);
		}
	}
}
