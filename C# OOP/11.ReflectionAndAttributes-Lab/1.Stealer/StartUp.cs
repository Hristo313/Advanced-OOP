using System;

namespace _1.Reflection
{
	public class StartUp
	{
		public static void Main()
		{
			Spy spy = new Spy();

			string result1 = spy.StealFieldInfo("Hacker", "username", "password");

			string result2 = spy.AnalyzeAcessModifiers("Hacker");

			string result3 = spy.RevealPrivateMethods("Hacker");

			string result4 = spy.CollectGettersAndSetters("Hacker");

			Console.WriteLine(result1);
			Console.WriteLine();
			Console.WriteLine(result2);
			Console.WriteLine();
			Console.WriteLine(result3);
			Console.WriteLine();
			Console.WriteLine(result4);
		}
	}
}
