namespace Aquarium.Tests
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Utilities.Messages;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        private Mock<IAquarium> fakeAquarium;

        [SetUp]
        public void Setup()
        {
            this.fakeAquarium = new Mock<IAquarium>();
            this.fakeAquarium.Setup(n => n.Name).Returns("Fish");
            this.fakeAquarium.Setup(c => c.Capacity).Returns(100);
        }

        [Test]
        public void Test_If_Constructor_Works_Correctly()
        {
            //IAquarium aquarium = new Aquarium("Fish", 100);

            //string expectedName = aquarium.Name;
            //int expectedCapacity = aquarium.Capacity;

            //Assert.That(expectedName, Is.EqualTo(aquarium.Name));
            //Assert.That(expectedCapacity, Is.EqualTo(aquarium.Capacity));

            string expectedName = this.fakeAquarium.Object.Name;
            int expectedCapacity = this.fakeAquarium.Object.Capacity;

            Assert.That(expectedName, Is.EqualTo(this.fakeAquarium.Object.Name));
            Assert.That(expectedCapacity, Is.EqualTo(this.fakeAquarium.Object.Capacity));
        }

        [TestCase("    ")]
        [TestCase(null)]
        [TestCase("")]
        public void Name_Should_Throws_Exception_If_Null_Or_Empty(string name)
        {
            //IAquarium aquarium = null;

            //Assert.That(
            //    () => aquarium = new Aquarium(name, 100),
            //    Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidAquariumName));

            this.fakeAquarium.Setup(n => n.Name).Returns(name);

            Assert.That(
                () => this.fakeAquarium.Object.Name,
                Throws.ArgumentException.With.Message.EqualTo(ExceptionMessages.InvalidAquariumName));
        }
    }
}