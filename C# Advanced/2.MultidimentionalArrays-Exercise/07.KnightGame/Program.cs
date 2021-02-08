using System;

namespace _07.KnightGame
{
	class Program
	{
		static void Main(string[] args)
		{
			int size = int.Parse(Console.ReadLine());

			char[,] chessBoard = new char[size, size];

			for (int row = 0; row < size; row++)
			{
				char[] currentRow = Console.ReadLine().ToCharArray();

				for (int col = 0; col < size; col++)
				{
					chessBoard[row, col] = currentRow[col];
				}
			}

			int knightsCount = 0;
			int maxAttacks = 0;
			int killerRow = 0;
			int killerCol = 0;

			while (true)
			{
				maxAttacks = 0;

				for (int row = 0; row < size; row++)
				{
					for (int col = 0; col < size; col++)
					{
						int currentKnights = 0;

						if (chessBoard[row, col] == 'K')
						{
							if (isValidCell(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
							{
								currentKnights++;
							}
							if (isValidCell(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
							{
								currentKnights++;
							}
						}

						if (currentKnights > maxAttacks)
						{
							maxAttacks = currentKnights;
							killerCol = col;
							killerRow = row;
						}
					}
				}

				if (maxAttacks > 0)
				{
					chessBoard[killerRow, killerCol] = '0';
					knightsCount++;
				}
				else
				{
					Console.WriteLine(knightsCount);
					break;
				}
			}
		}

		private static bool isValidCell(char[,] chessBoard, int row, int col)
		{
			if (row >= 0 && row < chessBoard.GetLength(0) &&
			   col >= 0 && col < chessBoard.GetLength(1))
			{
				return true;
			}

			return false;
		}
	}
}
