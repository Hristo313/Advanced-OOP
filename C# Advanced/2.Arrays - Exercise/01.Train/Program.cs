using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] people = new int[n];

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                people[i] = int.Parse(Console.ReadLine());
                sum += people[i];
                Console.Write(people[i] + " " );
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
