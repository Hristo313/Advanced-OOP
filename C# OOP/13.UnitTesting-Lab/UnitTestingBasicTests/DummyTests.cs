using _1.UnitTestingBasic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestingBasic.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int EXPERIENCE = 200;
        private const int ATTACK_POINTS = 30;
        private const int DEAD_DUMMY_HEALTH = 0;
        private const int ALLIVE_DUMMY_HEALTH = 100;

        private Dummy aliveDummy;
        private Dummy deadDummy;

        [SetUp]
        public void SetDummies()
		{
            this.aliveDummy = new Dummy(ALLIVE_DUMMY_HEALTH, EXPERIENCE);
            this.deadDummy = new Dummy(DEAD_DUMMY_HEALTH, EXPERIENCE);
        }

        [Test]
        public void Dummy_Should_Lose_Health_If_Attack()
        {
            //Act
            this.aliveDummy.TakeAttack(ATTACK_POINTS);

            //Assert
            Assert.That(this.aliveDummy.Health, Is.EqualTo(70));
        }

        [Test]
        public void Dummy_Throws_Exception_If_Attacked_And_Without_Health()
        {
            //Assert
            Assert.That(
                () => this.deadDummy.TakeAttack(ATTACK_POINTS),   //Act
                Throws.InvalidOperationException.With.Message.EqualTo("Dummy is dead."), "Dead dummies cannot be attacked.");
        }

        [Test]
        public void Dummy_Should_Give_Experience_If_Dead()
		{
            //Act
            var experience = this.deadDummy.GiveExperience();

            //Assert
            Assert.That(experience, Is.EqualTo(EXPERIENCE));
		}

        [Test]
        public void Dummy_Should_Not_Give_Experience_If_Allive()
		{
            //Assert
            Assert.That(
                () => this.aliveDummy.GiveExperience(),   //Act
                Throws.InvalidOperationException.With.Message.EqualTo("Target is not dead."));
        }
    }
}
