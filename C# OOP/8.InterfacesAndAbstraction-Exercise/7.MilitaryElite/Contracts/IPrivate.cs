using System;
using System.Collections.Generic;
using System.Text;

namespace _7.MilitaryElite.Contracts
{
	public interface IPrivate : ISoldier
	{
		decimal Salary { get; }
	}
}
