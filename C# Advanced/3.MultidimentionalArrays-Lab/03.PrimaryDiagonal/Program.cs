using System;
using System.Linq;

namespace _03.PrimaryDiagonal
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

			int sum = 0;

			for (int row = 0; row < sizeOfSquare; row++)
			{
				for (int col = 0; col < sizeOfSquare; col++)
				{
					if (row == col)
					{
						sum += square[row, col];
					}
				}
			}
			Console.WriteLine(sum);
		}
	}
}
