using _3.ShoppingSpree.Core;
using _3.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.ShoppingSpree
{
	public class StratUp
	{
		public static void Main(string[] args)
		{
			try
			{
				Engine engine = new Engine();
				engine.Run();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}		
		}
	}
}
