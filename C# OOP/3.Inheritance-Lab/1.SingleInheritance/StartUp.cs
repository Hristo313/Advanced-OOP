using System;

namespace _1.Inheritance
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Dog dog = new Dog();
			dog.Bark();
			dog.Eat();

			Puppy puppy = new Puppy();
			puppy.Eat();
			puppy.Bark();
			puppy.Weep();

			Cat cat = new Cat();
			cat.Eat();
			cat.Meow();
		}
	}
}
