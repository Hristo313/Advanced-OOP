using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using NUnit.Framework;
using UnitTestingBasic.Tests;
using _1.UnitTestingBasic;
using _1.UnitTestingBasic.Contracts;

namespace UnitTestingBasic.Tests
{
	[TestFixture]
	public class HeroTests
	{
		[Test]
		public void Hero_Should_Gain_Experience_If_Target_Dies()
		{
			const int EXPERIENCE = 200;

			//Arrange
			var fakeWeapon = Mock.Of<IWeapon>(); // When the fake class is empty

			var fakeTarget = new Mock<ITarget>(); // When the fake class has implementation

			fakeTarget
				.Setup(t => t.IsDead())
				.Returns(true);

			fakeTarget
				.Setup(t => t.GiveExperience())
				.Returns(EXPERIENCE);

			var hero = new Hero("TestHero", fakeWeapon);

			//Act
			hero.Attack(fakeTarget.Object);

			//Assert
			Assert.That(hero.Experience, Is.EqualTo(EXPERIENCE));
		}
	}
}
