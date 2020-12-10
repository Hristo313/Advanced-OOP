using _4.FightingArena;
using NUnit.Framework;
using System.Xml.Schema;

namespace FightingArena.Tests
{
    [TestFixture]
    public class ArenaTests
    {
        private const string NAME = "Pesho";
        private const int DAMAGE = 50;
        private const int HP = 100;

        private Arena arena;
        private Warrior warrior;
        private Warrior attacker;
        private Warrior defender;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warrior = new Warrior(NAME, DAMAGE, HP);

            this.attacker = new Warrior("Ivan", 10, 80);
            this.defender = new Warrior("Gosho", 5, 60);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            Assert.IsNotNull(this.arena.Warriors);
        }

        [Test]
        public void Test_Enroll_Adding_Warrior_Works_Correctly()
        {
            this.arena.Enroll(warrior);

            Assert.That(this.arena.Warriors, Has.Member(this.warrior));
        }

        [Test]
        public void Test_Enroll_Increasing_Count()
        {
            this.arena.Enroll(warrior);

            int expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(arena.Count));
        }

        [Test]
        public void Enrol_Throw_Exception_If_Adding_Same_Warrio()
        {
            this.arena.Enroll(warrior);           

            Assert.That(
                () => this.arena.Enroll(warrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Enrol_Throw_Exception_If_Adding_Same_Name_Warrior()
        {
            Warrior copy = new Warrior(NAME, 100, 300);

            this.arena.Enroll(copy);

            Assert.That(
                () => this.arena.Enroll(warrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void Test_Fighting_With_Missing_Attacker()
        {
            this.arena.Enroll(this.defender);

            Assert.That(
                () => this.arena.Fight(this.attacker.Name, this.defender.Name),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {attacker.Name} enrolled for the fights!"));
        }

        [Test]
        public void Test_Fighting_With_Missing_Defender()
        {
            this.arena.Enroll(this.attacker);

            Assert.That(
                () => this.arena.Fight(this.attacker.Name, this.defender.Name),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {defender.Name} enrolled for the fights!"));
        }

        [Test]
        public void Test_Fighting_Between_Two_Warriors()
        {
            int expectedAttackerHP = this.attacker.HP - this.defender.Damage;
            int expectedDefenderHP = this.defender.HP - this.attacker.Damage;

            this.arena.Enroll(this.defender);
            this.arena.Enroll(this.attacker);

            this.arena.Fight(this.attacker.Name, this.defender.Name);

            Assert.That(expectedAttackerHP, Is.EqualTo(attacker.HP));
            Assert.That(expectedDefenderHP, Is.EqualTo(defender.HP));
        }
    }
}