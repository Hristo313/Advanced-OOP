using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Stack
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			MyStack<int> myStack = new MyStack<int>();

			while (true)
			{
				string[] line = Console.ReadLine()
					.Split(new string[] {" ", ", " }, StringSplitOptions.RemoveEmptyEntries);

				string command = line[0];

				if (command == "END")
				{
					break;
				}

				if (command == "Push")
				{
					foreach (var item in line.Skip(1))
					{
						myStack.Push(int.Parse(item));
					}
				}
				else if (command == "Pop")
				{
					if(myStack.Count == 0)
					{
						Console.WriteLine("No elements");
					}
					else
					{
						myStack.Pop();
					}
				}
			}

			foreach (var item in myStack)
			{
				Console.WriteLine(item);
			}

			foreach (var item in myStack)
			{
				Console.WriteLine(item);
			}
		}
	}
}
