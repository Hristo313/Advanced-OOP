using System;

namespace _2.Animals
{
	public class StratUp
	{
		public static void Main(string[] args)
		{
			Animal cat = new Cat("Pesho", "Whiskas");
			Animal dog = new Dog("Gosho", "Meat");

			Console.WriteLine(cat.ExplainSelf());
			Console.WriteLine(dog.ExplainSelf());
		}
	}
}
