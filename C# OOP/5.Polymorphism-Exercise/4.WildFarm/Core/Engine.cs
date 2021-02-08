using _4.WildFarm.Core.Contracts;
using _4.WildFarm.Exceptions;
using _4.WildFarm.Factories;
using _4.WildFarm.Models.Animals;
using _4.WildFarm.Models.Animals.Contracts;
using _4.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Core
{
	public class Engine : IEngine
	{
		private ICollection<IAnimal> animals;
		private FoodFactory foodFactory;

		public Engine()
		{
			this.animals = new List<IAnimal>();
			this.foodFactory = new FoodFactory();
		}

		public void Run()
		{
			while (true)
			{
				string[] animalArgs = Console.ReadLine().Split();

				if (animalArgs[0] == "End")
				{
					break;
				}

				string[] foodArgs = Console.ReadLine().Split();

				IAnimal animal = ProduceAnimal(animalArgs);
				IFood food = this.foodFactory.ProduceFood(foodArgs[0], int.Parse(foodArgs[1]));

				this.animals.Add(animal);

				Console.WriteLine(animal.ProduceSount());

				try
				{
					animal.Feed(food);
				}
				catch (UneatableFoodException ufe)
				{
					Console.WriteLine(ufe.Message);
				}
			}

			PrintOutput();
		}

		private void PrintOutput()
		{
			foreach (IAnimal animal in this.animals)
			{
				Console.WriteLine(animal);
			}
		}

		private static IAnimal ProduceAnimal(string[] animalArgs)
		{
			IAnimal animal = null;

			string animalType = animalArgs[0];
			string name = animalArgs[1];
			double weight = double.Parse(animalArgs[2]);

			if (animalType == "Owl")
			{
				double wingSize = double.Parse(animalArgs[3]);
				animal = new Owl(name, weight, wingSize);
			}
			else if (animalType == "Hen")
			{
				double wingSize = double.Parse(animalArgs[3]);
				animal = new Hen(name, weight, wingSize);
			}
			else
			{
				string livingRegion = animalArgs[3];

				if (animalType == "Dog")
				{
					animal = new Dog(name, weight, livingRegion);
				}
				else if (animalType == "Mouse")
				{
					animal = new Dog(name, weight, livingRegion);
				}
				else
				{
					string breed = animalArgs[4];

					if (animalType == "Cat")
					{
						animal = new Cat(name, weight, livingRegion, breed);
					}
					else if (animalType == "Tiger")
					{
						animal = new Tiger(name, weight, livingRegion, breed);
					}
				}
			}

			return animal;
		}
	}
}
