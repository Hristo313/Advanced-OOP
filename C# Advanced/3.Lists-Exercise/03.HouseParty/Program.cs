using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.HouseParty
{
	class Program
	{
		static void Main(string[] args)
		{
			int commands = int.Parse(Console.ReadLine());

			List<string> guest = new List<string>();

			int counter = 1;

			while(counter <= commands)
			{
				string input = Console.ReadLine();
				string[] tokens = input.Split();
				string name = tokens[0];

				if(tokens[2] == "going!")
				{
					if(guest.Contains(name))
				    {
						Console.WriteLine($"{name} is already in the list!");
					}
					else
					{
						guest.Add(name);
					}
				}
				else if(tokens[2] == "not")
				{
					if(guest.Contains(name))
					{
						guest.Remove(name);
					}
					else
					{
						Console.WriteLine($"{name} is not in the list!");
					}
				}
				counter++;			
			}
			for (int i = 0; i < guest.Count; i++)
			{
			    Console.WriteLine(guest[i]);
			}
		}
	}
}