namespace Robot.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class Tests
    {
        private const int CAPACITY = 100;
        private const string NAME = "Robot";
        private const int MAX_BATTERY = 100;
        private const string JOB = "C# DEVEOPER";
        private const int BATTERY_USAGE = 20;

        private RobotManager robotManager;
        private Robot robot;

        [SetUp]
        public void Setup()
        {
            this.robotManager = new RobotManager(CAPACITY);
            this.robot = new Robot(NAME, MAX_BATTERY);
        }

        [Test]
        public void Test_Constructor_Should_Work_Correctly()
        {
            Assert.That(CAPACITY, Is.EqualTo(this.robotManager.Capacity));
        }

        [TestCase(-1)]
        public void Capacity_Throws_Exception_When_Below_Zero(int capacity)
        {
            Assert.That(
                () => this.robotManager = new RobotManager(capacity),
                Throws.ArgumentException.With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void Test_Count_Works_Correctly()
        {
            int expectedCount = 0;

            Assert.That(expectedCount, Is.EqualTo(this.robotManager.Count));
        }

        [Test]
        public void Test_Add_Works_Correctly()
        {
            this.robotManager.Add(this.robot);

            int expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(this.robotManager.Count));
        }

        [Test]
        public void Add_Throws_Exception_When__Adding_Existing_Robot()
        {
            this.robotManager.Add(this.robot);

            Assert.That(
                () => this.robotManager.Add(this.robot),
                Throws.InvalidOperationException.With.Message.EqualTo($"There is already a robot with name {NAME}!"));
        }

        [Test]
        public void Add_Throws_Exception_When_Full_Capacity()
        {
            this.robotManager = new RobotManager(0);

            Assert.That(
                () => robotManager.Add(this.robot),
                Throws.InvalidOperationException.With.Message.EqualTo("Not enough capacity!"));
        }


        [Test]
        public void Test_Remove_Works_Correctly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Remove(this.robot.Name);

            int expectedCount = 0;

            Assert.That(expectedCount, Is.EqualTo(this.robotManager.Count));
        }

        [TestCase("Rob")]
        public void Remove_Throws_Exception_When_Robot_Name_Not_Found(string nameToRemove)
        {
            this.robotManager.Add(this.robot);

            Assert.That(
                () => this.robotManager.Remove(nameToRemove),
                Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {nameToRemove} doesn't exist!"));
        }

        [Test]
        public void Test_Work_Works_Correctly()
        {
            this.robotManager.Add(this.robot);
            this.robotManager.Work(NAME, JOB, BATTERY_USAGE);

            int expectedBattery = this.robot.Battery - BATTERY_USAGE;
            this.robot.Battery -= BATTERY_USAGE;

            Assert.That(expectedBattery, Is.EqualTo(this.robot.Battery));
        }

        [TestCase("Rob")]
        public void Work_Throws_Exception_When_Robot_Name_Not_Found(string nameToWork)
        {
            this.robotManager.Add(this.robot);

            Assert.That(
                () => this.robotManager.Work(nameToWork, JOB, BATTERY_USAGE),
                Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {nameToWork} doesn't exist!"));
        }

        [TestCase(150)]
        public void Work_Throws_Exception_When_Robot_Battery_Less_Than_Usage(int batteryUsage)
        {
            this.robotManager.Add(this.robot);

            Assert.That(
                () => this.robotManager.Work(NAME, JOB, batteryUsage),
                Throws.InvalidOperationException.With.Message.EqualTo($"{NAME} doesn't have enough battery!"));
        }

        [Test]
        public void Test_Charge_Works_Correctly()
        {
            this.robotManager.Add(this.robot);

            this.robotManager.Charge(NAME);

            Assert.That(MAX_BATTERY, Is.EqualTo(this.robot.Battery));
        }

        [TestCase("Rob")]
        public void Charge_Throws_Exception_When_Robot_Name_Not_Found(string nameToCharge)
        {
            this.robotManager.Add(this.robot);

            Assert.That(
                () => this.robotManager.Charge(nameToCharge),
                Throws.InvalidOperationException.With.Message.EqualTo($"Robot with the name {nameToCharge} doesn't exist!"));
        }
    }
}