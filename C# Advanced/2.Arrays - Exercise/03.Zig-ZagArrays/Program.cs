using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] firstArr = new int[n];
            int[] secondArr = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if(i%2== 0)
                {
                    firstArr[i] = numbers[0];
                    secondArr[i] = numbers[1];
                }
                else
                {
                    firstArr[i] = numbers[1];
                    secondArr[i] = numbers[0];
                }
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(firstArr[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.Write(secondArr[i] + " ");
            }

        }
    }
}
