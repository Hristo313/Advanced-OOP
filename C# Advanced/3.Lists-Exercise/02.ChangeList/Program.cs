using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChangeList
{
	class Program
	{
		static void Main(string[] args)
		{
			List<int> numbers = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToList();

			while(true)
			{
				string command = Console.ReadLine();

				if(command == "end")
				{
					break;
				}

				string[] tokens = command.Split();

				if(tokens[0] == "Delete")
				{
					for (int i = 0; i < numbers.Count; i++)
					{
						int numberToDel = int.Parse(tokens[1]);
						numbers.Remove(numberToDel);
					}
				}
				if (tokens[0] == "Insert")
				{
					int numbersToInsert = int.Parse(tokens[1]);
					int indexToInsert = int.Parse(tokens[2]);
					numbers.Insert(indexToInsert, numbersToInsert);
				}
			}
			Console.WriteLine(string.Join(" ", numbers));
		}
	}
}