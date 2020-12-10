using _1.UnitTestingBasic;
using NUnit.Framework;
using System;

namespace UnitTestingBasicTests
{
	[TestFixture]
	public class AxeTests
	{
		private const int ATTACK_POINTS = 10;

		private Dummy dummy;

		[SetUp]
		public void SetAxe()
		{
			this.dummy = new Dummy(100, 500);
		}

		[Test]
		public void Axe_Should_Lose_Durability_After_Attack()
		{
			//Arrange
			Axe axe = new Axe(ATTACK_POINTS, 5);
			Dummy dummy = this.dummy;

			//Act
			axe.Attack(dummy);

			//Assert
			Assert.That(axe.DurabilityPoints, Is.EqualTo(4));
		}

		[Test]
		public void Axe_Should_Throw_Exception_If_An_Attack_Is_Made_With_Broken_Weapon()
		{
			//Arrange
			Axe axe = new Axe(ATTACK_POINTS, 0);
			Dummy dummy = this.dummy;

			//Assert
			Assert.That(
				() => axe.Attack(dummy),    //Act
				Throws.InvalidOperationException.With.Message.EqualTo("Axe is broken."));
		}
	}
}