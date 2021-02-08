using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int DNALength = int.Parse(Console.ReadLine());

            int length = 0;
            int sum = 0;
            int startindex = -1;
            int row = 0;
            int currentRow = 1;

            int[] DNA = new int[DNALength];

            while(true)
            {
                string line = Console.ReadLine();

                if (line == "Clone them!") 
                {
                    break;
                }
                int[] currentDNA = line
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int currentSum = 0;

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if(currentDNA[i]==1)
                    {
                        currentSum += 1;
                    }
                }

                if(currentRow == 1)
                {                   
                    sum = currentSum;
                    row = currentRow;
                    DNA = currentDNA;
                }

                int currentStartIndex = -1;
                int currentLength = 0;              

                for (int i = 0; i < currentDNA.Length; i++)
                {
                    if(currentDNA[i]==1)
                    {                       
                        currentStartIndex = i;                       
                        currentLength++;

                        if (currentLength > length)
                        {
                            length = currentLength;
                            startindex = currentStartIndex;
                            sum = currentSum;
                            row = currentRow;
                            DNA = currentDNA;
                        }
                        else if (currentLength == length)
                        {
                            if (currentStartIndex < startindex)
                            {
                                length = currentLength;
                                startindex = currentStartIndex;
                                sum = currentSum;
                                row = currentRow;
                                DNA = currentDNA;
                            }
                        }
                        else if (currentSum > sum)
                        {
                            length = currentLength;
                            startindex = currentStartIndex;
                            sum = currentSum;
                            row = currentRow;
                            DNA = currentDNA;
                        }
                    }
                    else
                    {
                        currentStartIndex = -1;
                        currentLength = 0;
                      
                    }
                }
                currentRow++;             
            }
            Console.WriteLine($"Best DNA sample {row} with sum: {sum}.");
            Console.WriteLine(string.Join(" ", DNA));
        }
    }
}
