using _4.WildFarm.Exceptions;
using _4.WildFarm.Models.Animals.Contracts;
using _4.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Models.Animals
{
	public abstract class Animal : IAnimal
	{
		private const string UneateableFoodMessage = "{0} does not eat {1}!";

		protected Animal(string name, double weight)
		{
			this.Name = name;
			this.Weight = weight;
		}

		public string Name { get; private set; }

		public double Weight { get; private set; }

		public int FoodEaten { get; private set; }

		//Abstact because they are different for every type of animal
		public abstract double WeightMultiplier { get; }

		//List of all foods that are being eaten by this animal
		public abstract ICollection<Type> PrefferedFoods { get; }

		public abstract string ProduceSount();

		public void Feed(IFood food)
		{
			if(!this.PrefferedFoods.Contains(food.GetType()))
			{
				string excMsg = string.Format(UneateableFoodMessage, this.GetType().Name, food.GetType().Name);
				throw new UneatableFoodException(excMsg);
			}

			this.Weight += this.WeightMultiplier * food.Quantity;

			this.FoodEaten += food.Quantity;
		}

		public override string ToString()
		{
			return $"{this.GetType().Name} [{this.Name}, ";
		}
	}
}
