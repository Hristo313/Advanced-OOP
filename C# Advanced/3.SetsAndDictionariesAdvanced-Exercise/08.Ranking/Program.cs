using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace _08.Ranking
{
	class Program
	{
		static void Main(string[] args)
		{
			var contests = new Dictionary<string, string>();
			string contestInput = Console.ReadLine();

			while (contestInput != "end of contests")
			{
				string[] line = contestInput.Split(":");
				contests.Add(line[0], line[1]);

				contestInput = Console.ReadLine();
			}

			var submissionResults = new SortedDictionary<string, Dictionary<string, int>>();
			string submissionInput = Console.ReadLine();

			while (submissionInput != "end of submissions")
			{
				string[] line = submissionInput.Split("=>");

				string contest = line[0];
				string pass = line[1];
				string username = line[2];
				int points = int.Parse(line[3]);

				if (!contests.ContainsKey(contest) || contests[contest] != pass)
				{
					submissionInput = Console.ReadLine();
					continue;
				}

				if (!submissionResults.ContainsKey(username))
				{
					submissionResults.Add(username, new Dictionary<string, int>());
					submissionResults[username].Add(contest, points);
				}
				else
				{
					Dictionary<string, int> temp = submissionResults[username];

					if (!submissionResults[username].ContainsKey(contest))
					{
						submissionResults[username].Add(contest, points);
					}
					else
					{
						int tempPoint = submissionResults[username][contest];

						if (submissionResults[username][contest] < points)
						{
							submissionResults[username][contest] = points;
						}
					}
				}

				submissionInput = Console.ReadLine();
			}

			var bestCandidate = submissionResults
				.OrderByDescending(kvp => kvp.Value.Values.Sum())
				.First();

			Console.WriteLine($"Best candidate is {bestCandidate.Key} with total {bestCandidate.Value.Values.Sum()} points.");
			Console.WriteLine("Ranking:");

			foreach ((string username, Dictionary<string, int> contestsResults) in submissionResults)
			{
				Console.WriteLine(username);

				foreach ((string contest, int points) in contestsResults.OrderByDescending(c => c.Value))
				{
					Console.WriteLine($"#  {contest} -> {points}");
				}
			}
		}
	}
}
