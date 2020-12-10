using System;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _04.SymbolInMatrix
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());

			char[,] matrix = new char[size, size];

			for (int row = 0; row < size; row++)
			{
				char[] currentRow = Console.ReadLine().ToCharArray();

				for (int col = 0; col < size; col++)
				{
					matrix[row, col] = currentRow[col];
				}
			}

			char symbol = char.Parse(Console.ReadLine());

			int rowIndex = 0;
			int colIndex = 0;

			for (int row = 0; row < size; row++)
			{
				for (int col = 0; col < size; col++)
				{
					if (matrix[row, col] == symbol)
					{
						rowIndex = row;
						colIndex = col;
						Console.WriteLine($"({rowIndex}, {colIndex})");
						return;
					}
				}
			}

			Console.WriteLine($"{symbol} does not occur in the matrix");
		}
	}
}
