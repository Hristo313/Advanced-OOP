using _3.Telephony.Contracts;
using _3.Telephony.Exceptions;
using _3.Telephony.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Telephony.Core
{
	public class Engine : IEngine
	{
		private StationaryPhone stationaryPhone;
		private Smartphone smartphone;

		public Engine()
		{
			this.stationaryPhone = new StationaryPhone();
			this.smartphone = new Smartphone();
		}

		public void Run()
		{
			string[] phoneNumbers = Console.ReadLine().Split();
			string[] sites = Console.ReadLine().Split();
			CallNumbers(phoneNumbers);
			BrowseSites(sites);
		}

		private void BrowseSites(string[] sites)
		{
			foreach (var url in sites)
			{
				try
				{
					Console.WriteLine(smartphone.Browse(url));
				}
				catch (InvalidURLException iue)
				{
					Console.WriteLine(iue.Message);
				}
			}
		}

		private void CallNumbers(string[] phoneNumbers)
		{
			foreach (var number in phoneNumbers)
			{
				try
				{
					if (number.Length == 7)
					{
						Console.WriteLine(stationaryPhone.Call(number));
					}
					else if (number.Length == 10)
					{
						Console.WriteLine(smartphone.Call(number));
					}
					else
					{
						throw new InvalidNumberException();
					}
				}
				catch (InvalidNumberException ine)
				{
					Console.WriteLine(ine.Message);
				}
			}
		}
	}
}
