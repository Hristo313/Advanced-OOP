using _1.DefineAnInterfaceIPerson.Contracts;
using _1.DefineAnInterfaceIPerson.Models;
using System;

namespace _1.DefineAnInterfaceIPerson
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			string name = Console.ReadLine();
			int age = int.Parse(Console.ReadLine());
			string id = Console.ReadLine();
			string birthdate = Console.ReadLine();

			IIdentifiable identifiable = new Citizen(name, age, id, birthdate);
			IBirthable birthable = new Citizen(name, age, id, birthdate);

			Console.WriteLine(identifiable.Id);
			Console.WriteLine(birthable.Birthdate);
		}
	}
}
