using _3.ShoppingSpree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.ShoppingSpree.Core
{
	public class Engine
	{
		private List<Person> people;
		private List<Product> products;

		public Engine()
		{
			this.people = new List<Person>();
			this.products = new List<Product>();
		}

		public void Run()
		{
			AddPeople();
			AddProducts();

			while (true)
			{
				string[] command = Console.ReadLine().Split();

				if (command[0] == "END")
				{
					break;
				}

				string personName = command[0];
				string productName = command[1];

				try
				{
					people.Where(p => p.Name == personName)
					.FirstOrDefault()
					.AddProduct((Product)products
					.Where(p => p.Name == productName)
					.FirstOrDefault());

					Console.WriteLine($"{personName} bought {productName}");
				}
				catch (InvalidOperationException ioe)
				{
					Console.WriteLine(ioe.Message); ;
				}
			}

			PrintOutput();
		}

		private void PrintOutput()
		{
			foreach (Person person in people)
			{
				Console.WriteLine(person);
				//if (person.Bag.Any())
				//{
				//	var result = person.Bag.Where(p => p.Cost <= person.Money).FirstOrDefault();

				//	if (result == null)
				//	{
				//		Console.WriteLine($"{person.Name} bought - {string.Join(", ", person.Bag)}");
				//	}
				//	else
				//	{
				//		Console.WriteLine($"{person.Name} can't afford - {result}");
				//	}
				//}
				//else
				//{
				//	Console.WriteLine($"{person.Name} - Nothing bought");
				//}
			}
		}

		private void AddPeople()
		{
			string[] clientsInfo = Console.ReadLine()
							.Split(";", StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < clientsInfo.Length; i++)
			{
				string[] clientArgs = clientsInfo[i]
					.Split("=", StringSplitOptions.RemoveEmptyEntries);

				string name = clientArgs[0];
				decimal money = decimal.Parse(clientArgs[1]);

				Person person = new Person(name, money);
				people.Add(person);
			}
		}

		private void AddProducts()
		{
			string[] productsInfo = Console.ReadLine()
							.Split(";", StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < productsInfo.Length; i++)
			{
				string[] productArgs = productsInfo[i]
					.Split("=", StringSplitOptions.RemoveEmptyEntries);

				string name = productArgs[0];
				decimal cost = decimal.Parse(productArgs[1]);

				Product product = new Product(name, cost);
				products.Add(product);
			}
		}
	}
}
