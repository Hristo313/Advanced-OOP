using _4.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Models.Animals.Contracts
{
	public interface IAnimal
	{
		string Name { get; }

		double Weight { get; }

		int FoodEaten { get; }

		string ProduceSount();

		void Feed(IFood food);
	}
}
