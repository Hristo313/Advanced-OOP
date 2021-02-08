using System;
using System.Linq;

namespace _03.CustomMinFunction
{
	class Program
	{
		static void Main(string[] args)
		{
			Func<int[], int> minFunc = (arr) =>
			{
				int minValue = int.MaxValue;

				for (int i = 0; i < arr.Length; i++)
				{
					int number = arr[i];

					if(number < minValue)
					{
						minValue = number;
					}
				}
				return minValue;
			};

			int[] arr = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			Console.WriteLine(minFunc(arr));
		}
	}
}
