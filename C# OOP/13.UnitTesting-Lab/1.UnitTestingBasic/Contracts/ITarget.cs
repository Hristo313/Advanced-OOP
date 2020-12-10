using System;
using System.Collections.Generic;
using System.Text;

namespace _1.UnitTestingBasic.Contracts
{
	public interface ITarget
	{
		bool IsDead();

		int GiveExperience();

		void TakeAttack(int damage);
	}
}
