using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                int number = numbers[i];

                for (int j = i+1; j < numbers.Length; j++)
                {
                    int secondNumber = numbers[j];

                    if(number <= secondNumber)
                    {
                        break;
                    }
                    else if ( j == numbers.Length - 1)
                    {
                        Console.Write(number + " ");
                   }
                }
            }
            Console.Write(numbers[numbers.Length-1]);
        }
    }
}
