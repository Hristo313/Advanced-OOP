using _5.FootballTeamGenerator.Common;
using _5.FootballTeamGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.FootballTeamGenerator.Core
{
	public class Engine
	{
		private List<Team> teams;

		public Engine()
		{
			this.teams = new List<Team>();
		}

		public void Run()
		{
			while(true)
			{
				try
				{
					string[] command = Console.ReadLine()
					.Split(";", StringSplitOptions.None);

					if (command[0] == "END")
					{
						break;
					}

					string commandType = command[0];

					if (commandType == "Team")
					{
						AddTeam(command);
					}
					else if (commandType == "Add")
					{
						AddPlayerToTeam(command);
					}
					else if (commandType == "Remove")
					{
						RemovePlayer(command);
					}
					else if (commandType == "Rating")
					{
						PrintRating(command);
					}
				}
				catch (ArgumentException ae)
				{
					Console.WriteLine(ae.Message);
				}
				catch(InvalidOperationException ioe)
				{
					Console.WriteLine(ioe.Message);
				}				
			}
		}

		private void PrintRating(string[] command)
		{
			string teamName = command[1];

			this.ValidateTeamExists(teamName);

			Team team = this.teams.First(t => t.Name == teamName);

			Console.WriteLine(team);
		}

		private void RemovePlayer(string[] command)
		{
			string teamName = command[1];
			string playerName = command[2];

			this.ValidateTeamExists(teamName);
			Team team = this.teams.First(t => t.Name == teamName);

			team.RemovePlayer(playerName);
		}

		private void AddPlayerToTeam(string[] command)
		{
			string teamName = command[1];
			string playerName = command[2];

			this.ValidateTeamExists(teamName);
			Team team = this.teams.First(t => t.Name == teamName);

			Stats stats = this.CreateStats(command.Skip(3).ToArray());

			Player player = new Player(playerName, stats);
			team.AddPlayer(player);
		}

		private Stats CreateStats(string[] command)
		{
			int endurance = int.Parse(command[0]);
			int sprint = int.Parse(command[1]);
			int dribble= int.Parse(command[2]);
			int passing = int.Parse(command[3]);
			int shooting = int.Parse(command[4]);

			Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

			return stats;
		}

		private void ValidateTeamExists(string name)
		{
			if(!this.teams.Any(t => t.Name == name))
			{
				throw new ArgumentException(string.Format
					(GlobalConstants.MissingTeamExceptionMessage, name));
			}
		}

		private void AddTeam(string[] command)
		{
			string teamName = command[1];

			Team team = new Team(teamName);

			teams.Add(team);
		}
	}
}
