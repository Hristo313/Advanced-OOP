using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MaxSequenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int maxCount = 1;
            int count = 1;
            int position = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i - 1 >= 0 && arr[i] == arr[i - 1])
                {
                    count++;

                    if (maxCount < count)
                    {
                        maxCount = count;
                        position = i - count + 1;
                    }
                }
                else
                {
                    count = 1;
                }
            }
            for (int i = position; i < position + maxCount; i++)
            {
                Console.Write(arr[i] + " ");
            }           
        }
    }           
}
