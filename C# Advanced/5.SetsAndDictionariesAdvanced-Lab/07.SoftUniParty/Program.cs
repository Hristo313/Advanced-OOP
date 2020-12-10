using System;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
	class Program
	{
		static void Main(string[] args)
		{
			var vip = new HashSet<string>();
			var regular = new HashSet<string>();

			int allGuests = 0;
			int comingGuests = 0;
			bool hasToBreak = false;

			while (true)
			{
				string guests = Console.ReadLine();

				if (guests == "PARTY")
				{
					while (true)
					{
						guests = Console.ReadLine();

						if (guests == "END")
						{
							hasToBreak = true;
							break;
						}

						if (guests[0] > 47 && guests[0] < 58)
						{
							vip.Remove(guests);						
						}
						else
						{
							regular.Remove(guests);
						}

						comingGuests++;					
					}
				}

				if (hasToBreak)
				{
					break;
				}
				else
				{
					if (guests[0] > 47 && guests[0] < 58)
					{
						vip.Add(guests);
					}
					else
					{
						regular.Add(guests);
					}

					allGuests++;
				}
			}

			int notCommingGuests = allGuests - comingGuests;

			Console.WriteLine(notCommingGuests);

			foreach (var guest in vip)
			{
				Console.WriteLine(guest);
			}

			foreach (var guest in regular)
			{
				Console.WriteLine(guest);
			}
		}
	}
}
