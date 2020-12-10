using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
	class Program
	{
		static void Main(string[] args)
		{
			var vloggerWithFollowers = new Dictionary<string, SortedSet<string>>();
			var vloggerWithFollowings = new Dictionary<string, HashSet<string>>();

			while (true)
			{
				string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string vlogger = line[0];
				
				if (vlogger == "Statistics")
				{
					break;
				}

				string command = line[1];

				if (command == "joined")
				{
					if (!vloggerWithFollowers.ContainsKey(vlogger))
					{
						vloggerWithFollowers[vlogger] = new SortedSet<string>();
					}
					if (!vloggerWithFollowings.ContainsKey(vlogger))
					{
						vloggerWithFollowings[vlogger] = new HashSet<string>();
					}
				}

				if (command == "followed")
				{
					string followed = line[2];

					if (followed != vlogger)
					{
						if (vloggerWithFollowers.ContainsKey(followed) && vloggerWithFollowings.ContainsKey(vlogger))
						// nqma znachenie v koe dictionary dobavqme i koi dobavqme
						{
							vloggerWithFollowers[followed].Add(vlogger);
							vloggerWithFollowings[vlogger].Add(followed);
						}
					}
				}
			}

			vloggerWithFollowers = vloggerWithFollowers
				.OrderByDescending(kvp => kvp.Value.Count)
				// this is the count of following
				.ThenBy(kvp => vloggerWithFollowings[kvp.Key].Count)
				.ToDictionary(a => a.Key, b => b.Value);

			Console.WriteLine($"The V-Logger has a total of {vloggerWithFollowers.Count} vloggers in its logs.");

			var mostFamousVlogger = vloggerWithFollowers.First();
			string mostFamousVloggerName = mostFamousVlogger.Key;
			SortedSet<string> mostFamousVloggerFollowers = mostFamousVlogger.Value;

			int counter = 1;

			Console.WriteLine($"{counter++}. {mostFamousVloggerName} : " +
				$"{mostFamousVloggerFollowers.Count} followers, " +
				$"{vloggerWithFollowings[mostFamousVloggerName].Count} following");

			foreach (var follower in mostFamousVloggerFollowers)
			{
				Console.WriteLine($"*  {follower}");
			}

			foreach (var vloggerFollowersKvp in vloggerWithFollowers.Skip(1))
			{
				string name = vloggerFollowersKvp.Key;
				SortedSet<string> followers = vloggerFollowersKvp.Value;
				Console.WriteLine($"{counter++}. {name} : {followers.Count} followers, {vloggerWithFollowings[name].Count} following");
			}
		}
	}
}
