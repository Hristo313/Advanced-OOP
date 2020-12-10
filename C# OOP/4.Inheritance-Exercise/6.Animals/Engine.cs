using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals
{
	public class Engine
	{
		private readonly List<Animal> animals;

		public Engine()
		{
			this.animals = new List<Animal>();
		}

		public void Run()
		{
			while (true)
			{
				string input = Console.ReadLine();

				if (input == "Beast!")
				{
					break;
				}

				string[] animalArgs = Console.ReadLine().Split();

				Animal animal = GetAnimal(input, animalArgs);

				this.animals.Add(animal);
			}

			PrintOutput();
		}

		private void PrintOutput()
		{
			foreach (Animal animal in this.animals)
			{
				Console.WriteLine(animal);
			}
		}

		private static Animal GetAnimal(string input, string[] animalArgs)
		{
			string name = animalArgs[0];
			int age = int.Parse(animalArgs[1]);

			Animal animal = null;

			if (input == "Dog")
			{
				animal = new Dog(name, age, animalArgs[2]);
			}
			else if (input == "Cat")
			{
				animal = new Cat(name, age, animalArgs[2]);
			}
			else if (input == "Frog")
			{
				animal = new Frog(name, age, animalArgs[2]);
			}
			else if (input == "Kitten")
			{
				animal = new Kitten(name, age);
			}
			else if (input == "Tomcat")
			{
				animal = new Tomcat(name, age);
			}
			else
			{
				throw new ArgumentException("Invalid input!");
			}

			return animal;
		}
	}
}
