using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Animals
{
	public class Cat : Animal
	{
		public Cat(string name, string favouriteFood)
           : base(name, favouriteFood)
		{ 
		}

		public sealed override string ExplainSelf()
		{
			return base.ExplainSelf() + Environment.NewLine + "MEOW";
		}
	}
}
