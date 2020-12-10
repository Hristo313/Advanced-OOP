using System;
using System.Collections.Generic;
using System.Text;

namespace _7.RawData
{
	public class Car
	{
		private string model;
		private Engine engine;
		private Cargo cargo;
		private List<Tire> tires;

		public Car(string model, int speed,int power, int weight, string type, double tire1Pressure, int tire1Age,
			double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age)
		{
			this.Model = model;
			this.Engine = new Engine(speed, power);
			this.Cargo = new Cargo(weight, type);
			this.tires = new List<Tire>()
			{
				new Tire(tire1Age, tire1Pressure),
				new Tire(tire2Age, tire2Pressure),
				new Tire(tire3Age, tire3Pressure),
				new Tire(tire4Age, tire4Pressure)
			};
		}

		//How shoud constructor looks like 
		public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
		{
			this.Model = model;
			this.Engine = engine;
			this.Cargo = cargo;
			this.tires = tires;
		}

		public string Model { get; set; }

		public Engine Engine { get; set; }

		public Cargo Cargo { get; set; }

		public List<Tire> Tires { get; }

		public override string ToString()
		{
			return this.Model;
		}
	}
}
