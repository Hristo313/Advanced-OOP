using _7.MilitaryElite.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
	public interface IMission
	{
		string CodeName { get; }

		State State { get; }

		void CompleteMission();
	}
}
