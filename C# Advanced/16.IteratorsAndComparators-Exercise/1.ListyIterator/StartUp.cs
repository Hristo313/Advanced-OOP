using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace _1.ListyIterator
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			ListyIterator<string> listyIterator = null;

			while (true)
			{
				try
				{
					string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
					string command = line[0];

					if (command == "END")
					{
						break;
					}

					switch (command)
					{
						case "Create":
							List<string> elements = line.Skip(1).ToList();
							listyIterator = new ListyIterator<string>(elements);
							break;

						case "Move":
							Console.WriteLine(listyIterator.Move());
							break;

						case "Print":
							listyIterator.Print();
							break;

						case "HasNext":
							Console.WriteLine(listyIterator.HasNext());
							break;

						case "PrintAll":
							foreach (var item in listyIterator)
							{
								Console.Write(item + " ");
							}
							Console.WriteLine();
							break;
					}
				}
				catch (InvalidOperationException e)
				{
					Console.WriteLine(e.Message);
				}
			}
		}
	}
}
