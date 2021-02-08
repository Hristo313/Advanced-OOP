using System;
using System.Collections.Generic;

namespace _01._ValidUsernames
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] usernames = Console.ReadLine().Split(", ");
			List<string> validUsernames = new List<string>();

			for (int i = 0; i < usernames.Length; i++)
			{
				string username = usernames[i];

				if (username.Length >= 3 && username.Length <= 16)
				{
					bool validateContent = true;

					for (int j = 0; j < username.Length; j++)
					{
						char symbol = username[j];
						if (char.IsLetterOrDigit(symbol) == false && symbol != '_' && symbol != '-')
						{
							validateContent = false;
						}
					}

					if (validateContent == true)
					{
						validUsernames.Add(username);
					}
				}
			}
			Console.WriteLine(string.Join(Environment.NewLine, validUsernames));
		}
	}
}