using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Core.Contracts;
using _7.MilitaryElite.Exceptions;
using _7.MilitaryElite.IO.Contracts;
using _7.MilitaryElite.Models;

namespace _7.MilitaryElite.Core
{
	public class Engine : IEngine
	{
		private IReader reader;
		private IWritter writter;

		private ICollection<ISoldier> soldiers;

		public Engine()
		{
			this.soldiers = new List<ISoldier>();
		}

		public Engine(IReader reader, IWritter writter)
			: this()
		{
			this.reader = reader;
			this.writter = writter;
		}

		public void Run()
		{
			while (true)
			{
				string[] command = reader.ReadLine().Split();

				if (command[0] == "End")
				{
					break;
				}

				string soldierType = command[0];
				int id = int.Parse(command[1]);
				string firstName = command[2];
				string lastName = command[3];

				ISoldier soldier = null;

				if (soldierType == "Private")
				{
					decimal salary = decimal.Parse(command[4]);

					soldier = new Private(id, firstName, lastName, salary);
				}
				else if (soldierType == "LieutenantGeneral")
				{
					soldier = AddGeneral(command, id, firstName, lastName);
				}
				else if (soldierType == "Engineer")
				{
					decimal salary = decimal.Parse(command[4]);
					string corps = command[5];

					try
					{
						IEngineer engineer = CreateEngineer(command, id, firstName, lastName, salary, corps);
						soldier = engineer;
					}
					catch (InvalidCorpsException ice)
					{
						continue;
					}
				}
				else if (soldierType == "Commando")
				{
					decimal salary = decimal.Parse(command[4]);
					string corps = command[5];

					try
					{
						ICommando commando = GetCommando(command, id, firstName, lastName, salary, corps);
						soldier = commando;
					}
					catch (Exception)
					{

						throw;
					}
				}
				else if (soldierType == "Spy")
				{
					int codeNumber = int.Parse(command[4]);

					soldier = new Spy(id, firstName, lastName, codeNumber);
				}

				if (soldier != null)
				{
					this.soldiers.Add(soldier);
				}
			}

			foreach (var soldier in this.soldiers)
			{
				this.writter.WriteLine(soldier.ToString());
			}
		}

		private static ICommando GetCommando(string[] command, int id, string firstName, string lastName, decimal salary, string corps)
		{
			ICommando commando = new Commando(id, firstName, lastName, salary, corps);

			string[] missionArgs = command.Skip(6).ToArray();

			for (int i = 0; i < missionArgs.Length; i += 2)
			{
				try
				{
					string missionCodeName = missionArgs[i];
					string missionState = missionArgs[1];

					IMission mission = new Mission(missionCodeName, missionState);

					commando.AddMission(mission);
				}
				catch (InvalidMissionCompletionException imce)
				{
					continue;
				}
			}

			return commando;
		}

		private static IEngineer CreateEngineer(string[] command, int id, string firstName, string lastName, decimal salary, string corps)
		{
			IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

			string[] repairArgs = command.Skip(6).ToArray();

			for (int i = 0; i < repairArgs.Length; i += 2)
			{
				string partName = repairArgs[i];
				int hoursWorked = int.Parse(repairArgs[i + 1]);

				IRepair repair = new Repair(partName, hoursWorked);

				engineer.AddRepair(repair);
			}

			return engineer;
		}

		private ISoldier AddGeneral(string[] command, int id, string firstName, string lastName)
		{
			ISoldier soldier;
			decimal salary = decimal.Parse(command[4]);

			ILieutenantGeneral general = new LieutenantGeneral(id, firstName, lastName, salary);

			foreach (var pid in command.Skip(5))
			{
				ISoldier privateToAdd = this.soldiers
					.First(s => s.Id == int.Parse(pid));

				general.AddPrivate(privateToAdd);
			}

			soldier = general;
			return soldier;
		}
	}
}
