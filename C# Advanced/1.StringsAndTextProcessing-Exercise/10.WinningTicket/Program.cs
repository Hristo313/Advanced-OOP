using System;

namespace _10.WinningTicket
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] tickets = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			for (int i = 0; i < tickets.Length; i++)
			{
				string ticket = tickets[i];

				if (ticket.Length != 20)
				{
					Console.WriteLine("invalid ticket");
					continue;
				}

				string leftSide = ticket.Substring(0, 10);
				string rightSide = ticket.Substring(10);

				int length = 0;
				char symbol = ' ';

				for (int j = 6; j <= 10; j++)
				{
					if (leftSide.Contains(new string('@', j)) && rightSide.Contains(new string('@', j)))
					{
						length = j;
						symbol = '@';
					}

					else if (leftSide.Contains(new string('$', j)) && rightSide.Contains(new string('$', j)))
					{
						length = j;
						symbol = '$';
					}

					else if (leftSide.Contains(new string('#', j)) && rightSide.Contains(new string('#', j)))
					{
						length = j;
						symbol = '#';
					}

					else if (leftSide.Contains(new string('^', j)) && rightSide.Contains(new string('^', j)))
					{
						length = j;
						symbol = '^';
					}
				}
				if (length < 6)
				{
					Console.WriteLine($"ticket \"{ticket}\" - no match");
				}

				else if (length == 10)
				{
					Console.WriteLine($"ticket \"{ticket}\" - {length}{symbol} Jackpot!");
				}

				else
				{
					Console.WriteLine($"ticket \"{ticket}\" - {length}{symbol}");
				}
			}
		}
	}
}