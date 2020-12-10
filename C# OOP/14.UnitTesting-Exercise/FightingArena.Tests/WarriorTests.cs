using _4.FightingArena;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FightingArena.Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private const string NAME = "Pesho";
        private const int DAMAGE = 50;
        private const int HP = 100;

        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            this.warrior = new Warrior(NAME, DAMAGE, HP);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            string actualName = this.warrior.Name;
            int actualDmg = this.warrior.Damage;
            int actualHP = this.warrior.HP;

            Assert.That(NAME, Is.EqualTo(actualName));
            Assert.That(DAMAGE, Is.EqualTo(actualDmg));
            Assert.That(HP, Is.EqualTo(actualHP));
        }

        [TestCase("   ")]
        [TestCase(null)]
        [TestCase("")]
        public void Name_Throws_Exception_If_Null_Or_Whitespace(string name)
        {
            Assert.That(
                () => warrior = new Warrior(name, DAMAGE, HP),
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [TestCase(0)]
        [TestCase(-4)]
        public void Damage_Throws_Exception_If_Not_Possitive(int damage)
        {
            Assert.That(
                () => warrior = new Warrior(NAME, damage, HP),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [TestCase(-1)]
        [TestCase(-100)]
        public void HP_Throws_Exception_If_Less_Than_Zero(int Hp)
        {
            Assert.That(
                () => warrior = new Warrior(NAME, DAMAGE, Hp),
                Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [TestCase(5)]
        [TestCase(30)]
        public void Attacker_HP_Throws_Exception_If_Less_Than_30(int attackerHP)
        {
            Warrior attacker = new Warrior("Attacker", 130, attackerHP);
            Warrior defender = new Warrior("Defender", 160, 40);

            Assert.That(
                () => attacker.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [TestCase(5)]
        [TestCase(30)]
        public void Attack_Throws_Exception_If_Deffender_HP_Is_Less_Than_30(int defenderHP)
        {
            Warrior attacker = new Warrior("Attacker", 130, 100);
            Warrior defender = new Warrior("Defender", 160, defenderHP);

            Assert.That(
                () => attacker.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo($"Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void Attacker_HP_Throws_Exception_If_Less_Than_Defender_Damage()
        {
            Warrior attacker = new Warrior("Attacker", 130, 50);
            Warrior defender = new Warrior("Defender", 70, 50);

            Assert.That(
                () => attacker.Attack(defender),
                Throws.InvalidOperationException.With.Message.EqualTo($"You are trying to attack too strong enemy"));
        }

        [Test]
        public void Test_Attack_Should_Decrease_With_Deffender_Damage()
        {
            Warrior attacker = new Warrior("Attacker", 40, 50);
            Warrior defender = new Warrior("Defender", 30, 50);

            int expectedAttackerHP = attacker.HP - defender.Damage;
            int expectedDefenderHP = defender.HP - attacker.Damage;

            attacker.Attack(defender);

            Assert.That(expectedAttackerHP, Is.EqualTo(attacker.HP));
            Assert.That(expectedDefenderHP, Is.EqualTo(defender.HP));
        }

        [Test]
        public void Test_Attack_Killing_Enemy()
        {
            Warrior attacker = new Warrior("Attacker", 60, 50);
            Warrior defender = new Warrior("Defender", 30, 50);

            int expectedAttackerHP = attacker.HP - defender.Damage;
            int expectedDefenderHP = 0;

            attacker.Attack(defender);

            Assert.That(expectedAttackerHP, Is.EqualTo(attacker.HP));
            Assert.That(expectedDefenderHP, Is.EqualTo(defender.HP));
        }
    }
}
