using System;
using System.Collections.Generic;

namespace _5.StackOfStrings
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			StackOfStrings stack = new StackOfStrings();

			Console.WriteLine(stack.IsEmpty());

			stack.AddRange(new string[] {"Ivan", "Pesho"});

			Console.WriteLine(stack.IsEmpty());
		}
	}
}
