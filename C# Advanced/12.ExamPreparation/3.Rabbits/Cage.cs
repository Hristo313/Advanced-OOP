using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace _3.Rabbits
{
	public class Cage
	{
		private readonly List<Rabbit> data;

		private Cage()
		{
			this.data = new List<Rabbit>();
		}

		public Cage(string name, int capacity)
			: this()
		{
			this.Name = name;
			this.Capacity = capacity;			
		}

		public string Name { get; set; }

		public int Capacity { get; set; }

		public int Count => this.data.Count;

		public void Add(Rabbit rabbit)
		{
			if (this.Capacity >= this.Count)
			{
				this.data.Add(rabbit);
			}
		}

		public bool RemoveRabbit(string name)
		{
			foreach (var rabbit in this.data.Where(r => r.Name == name))
			{
				this.data.Remove(rabbit);
				return true;
			}

			return false;
		}

		public void RemoveSpecies(string species)
		{
			foreach (var rabbit in this.data.Where(r => r.Species == species))
			{
				data.Remove(rabbit);
			}
		}

		public Rabbit SellRabbit(string name)
		{
			foreach (var rabbit in this.data.Where(r => r.Name == name))
			{
				rabbit.Available = false;
				return rabbit;
			}

			return null;
		}

		public Rabbit[] SellRabbitsBySpecies(string species)
		{
			Rabbit[] rabbitsWithSpecies = this.data.Where(r => r.Species == species).ToArray();

			foreach (var rabbit in rabbitsWithSpecies)
			{
				rabbit.Available = false;
			}

			return rabbitsWithSpecies;
		}

		public string Report()
		{
			StringBuilder sb = new StringBuilder();

			sb.AppendLine( $"Rabbits available at {this.Name}:");

			foreach (var rabbit in this.data.Where(r => r.Available == true))
			{
				sb.AppendLine($"{rabbit}");
			}

			return sb.ToString().TrimEnd();
		}
	}
}
