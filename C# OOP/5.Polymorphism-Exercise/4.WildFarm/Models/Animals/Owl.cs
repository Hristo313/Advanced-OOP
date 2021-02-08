using _4.WildFarm.Models.Foods;
using _4.WildFarm.Models.Foods.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.WildFarm.Models.Animals
{
	public class Owl : Bird
	{
		private const double WEIGHT_MULTIPLIER = 0.25;

		public Owl(string name, double weight, double wingSize) 
			: base(name, weight, wingSize)
		{
		}

		public override double WeightMultiplier => WEIGHT_MULTIPLIER;

		public override ICollection<Type> PrefferedFoods
			=> new List<Type>() 
			{ 
				typeof(Meat) 
			};

		public override string ProduceSount()
		{
			return "Hoot Hoot";
		}
	}
}
