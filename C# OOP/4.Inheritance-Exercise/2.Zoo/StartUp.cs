namespace _2.Zoo
{
	using System;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			Reptile reptile = new Reptile("Reptile");
			Lizard lizard = new Lizard("Lizard");
			Gorilla gorilla = new Gorilla("Gorilla");

			Console.WriteLine(reptile.Name);
			Console.WriteLine(lizard.Name);
			Console.WriteLine(gorilla.Name);
		}
	}
}
