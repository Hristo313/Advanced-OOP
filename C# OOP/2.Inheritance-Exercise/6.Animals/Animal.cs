using System;
using System.Collections.Generic;
using System.Text;

namespace _6.Animals
{
	public abstract class Animal
	{
		private string name;
		private int age;
		private string gender;

		public Animal(string name, int age, string gender)
		{
			this.Name = name;
			this.Age = age;
			this.Gender = gender;
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			private set
			{
				if(string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Invalid input!");
				}

				this.name = value;
			}
		}

		public int Age
		{
			get
			{
				return this.age;
			}
			private set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Invalid input!");
				}

				this.age = value;
			}
		}

		public string Gender
		{
			get
			{
				return this.gender;
			}
			private set
			{
				if (value != "Male" && value != "Female")
				{
					throw new ArgumentException("Invalid input!");
				}

				this.gender = value;
			}
		}

		public abstract string ProduceSound();

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb
				.AppendLine($"{this.GetType().Name}")
				.AppendLine($"{this.Name} {this.Age} {this.Gender}")
				.AppendLine($"{this.ProduceSound()}");

			return sb.ToString().TrimEnd();
		}
	}
}
