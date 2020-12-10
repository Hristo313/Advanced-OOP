using System;
using System.Collections.Generic;

namespace _01.UniqueUsernames
{
	class Program
	{
		static void Main(string[] args)
		{
			int usernames = int.Parse(Console.ReadLine());

			var names = new HashSet<string>();

			for (int i = 0; i < usernames; i++)
			{
				string name = Console.ReadLine();
				names.Add(name);
			}

			foreach (var name in names)
			{
				Console.WriteLine(name);
			}
		}
	}
}
