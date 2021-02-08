using System;
using System.Linq;

namespace _05.SnakeMoves
{
	class Program
	{
		static void Main(string[] args)
		{
			int[] dimentions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
			int rows = dimentions[0];
			int colums = dimentions[1];
			char[,] matrix = new char[rows, colums];

			string snake = Console.ReadLine();
			int counter = 0;

			for (int row = 0; row < rows; row++)
			{
				if (row % 2 == 0)
				{
					for (int col = 0; col < colums; col++)
					{
						if (counter == snake.Length)
						{
							counter = 0;
						}

						matrix[row, col] = snake[counter++];
					}
				}
				else
				{
					for (int col = colums - 1; col >= 0; col--)
					{
						if (counter == snake.Length)
						{
							counter = 0;
						}

						matrix[row, col] = snake[counter++];
					}
				}

			}

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < colums; col++)
				{
					Console.Write(matrix[row, col]);
				}
				Console.WriteLine();
			}
		}
	}
}
