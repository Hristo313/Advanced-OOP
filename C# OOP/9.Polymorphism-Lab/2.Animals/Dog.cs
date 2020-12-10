using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Animals
{
	public class Dog : Animal
	{
		public Dog(string name, string favouriteFood)
            : base(name, favouriteFood) 
		{ 
		}

		public sealed override string ExplainSelf()
		{
			return base.ExplainSelf() + Environment.NewLine + "BARK";
		}
	}
}
