using System;
using System.Linq;

namespace _1.RecursiveArraySum
{
	public class Recursion
	{
		public static void Main(string[] args)
		{
			int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
			Console.WriteLine(Sum(arr, 0));

			int n = int.Parse(Console.ReadLine());
			Console.WriteLine(Factorial(n));
		}

		public static int Factorial(int n)
		{
			if(n == 1)
			{
				return 1;
			}

			return n * Factorial(n - 1);
		}

		public static int Sum(int[] arr, int index)
		{
			if(index == arr.Length - 1)
			{
				return arr[index];
			}

			return arr[index] + Sum(arr, index + 1);
		}

		public static int Pow(int x, int n)
		{
			if (n == 1)
			{
				return x;
			}

			return x * Pow(x, n - 1);
		}
	}
}
