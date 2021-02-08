using System;
using System.Linq;

namespace _3.JediGalaxy
{
	public class Engine
	{
		private int[,] matrix;
		private long sum;

		public Engine()
		{

		}

		public void Run()
		{
			int[] dimensions = Console.ReadLine()
				.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int rows = dimensions[0];
			int cols = dimensions[1];

			GetMatrix(rows, cols);

			sum = 0;

			string command = Console.ReadLine();

			while (command != "Let the Force be with you")
			{
				this.ProcessCoordinates(command);

				command = Console.ReadLine();
			}

			Console.WriteLine(sum);
		}

		private void ProcessCoordinates(string command)
		{
			int[] ivoCoordinates = command
				.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int[] evilCoordinates = Console.ReadLine()
				.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			this.MoveEvilPlayer(evilCoordinates);
			this.MoveIvoPlayer(ivoCoordinates);
		}

		private void MoveIvoPlayer(int[] ivoCoordinates)
		{
			int ivoRow = ivoCoordinates[0];
			int ivoCol = ivoCoordinates[1];

			while (ivoRow >= 0 && ivoCol < matrix.GetLength(1))
			{
				if (this.IsInside(ivoRow, ivoCol))
				{
					sum += matrix[ivoRow, ivoCol];
				}

				ivoCol++;
				ivoRow--;
			}
		}

		private bool IsInside(int row, int col)
		{
			bool isInside = row >= 0 && row < matrix.GetLength(0)
				&& col >= 0 && col < matrix.GetLength(1);

			return isInside;
		}

		private void MoveEvilPlayer(int[] evilCoordinates)
		{
			int evilRow = evilCoordinates[0];
			int evilCol = evilCoordinates[1];

			while (evilRow >= 0 && evilCol >= 0)
			{
				if (this.IsInside(evilRow, evilCol))
				{
					matrix[evilRow, evilCol] = 0;
				}

				evilRow--;
				evilCol--;
			}
		}

		private void GetMatrix(int rows, int cols)
		{
			matrix = new int[rows, cols];

			int currentNum = 0;

			for (int row = 0; row < rows; row++)
			{
				for (int col = 0; col < cols; col++)
				{
					matrix[row, col] = currentNum;
					currentNum++;
				}
			}
		}
	}
}
