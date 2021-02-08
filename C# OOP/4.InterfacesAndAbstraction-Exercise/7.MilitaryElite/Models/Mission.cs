using _7.MilitaryElite.Contracts;
using _7.MilitaryElite.Enumerations;
using _7.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace _7.MilitaryElite.Models
{
	public class Mission : IMission
	{
		public Mission(string codeName, string state)
		{
			this.CodeName = codeName;
			this.State = this.TryParseState(state);
		}

		public string CodeName { get; private set; }

		public State State { get; private set; }

		public void CompleteMission()
		{
			if(this.State == State.Finished)
			{
				throw new InvalidMissionCompletionException();
			}

			this.State = State.Finished;
		}

		private State TryParseState(string stateStr)
		{
			bool parsed = Enum.TryParse<State>(stateStr, out State state);

			if(!parsed)
			{
				throw new InvalidMissionStateException();
			}

			return state;
		}

		public override string ToString()
		{
			return $"Code Name: {this.CodeName} State: {this.State.ToString()}";
		}
	}
}
