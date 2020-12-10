using _1.Database;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        private Database database;
        private readonly int[] initialData = new int[] { 1, 2 };

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        public void Test_If_Constructor_Works_Correctly(int[] data)
        {
            this.database = new Database(data);

            int expectedCount = data.Length;
            int actualCount = this.database.Count;

            //Assert.That(expectedCount, Is.EqualTo(actualCount));
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Constructor_Should_Throw_Exception_When_Bigger_Collection()
        {
            //Arrange
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };

            //Assert
            Assert.That(
                () => this.database = new Database(data), //Act
                Throws.InvalidOperationException);
        }

        [Test]
        public void Add_Should_Increase_Count_When_Aded_Successfully()
        {
            this.database.Add(5);

            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]
        public void Add_Should_Throw_Exception_When_Database_Full()
        {
            for (int i = 3; i <= 16; i++)
            {
                this.database.Add(i);
            }

            Assert.That(
                () => this.database.Add(17),
                Throws.InvalidOperationException.With.Message.EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_Should_Decrease_Count_When_Success()
        {
            this.database.Remove();

            int expected = 1;
            int actual = this.database.Count;

            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(new int[] { })]
        public void Remove_Should_Throw_Exception_When_Database_Empty(int[] data)
        {
            this.database = new Database(data);

            Assert.That(
                () => this.database.Remove(),
                Throws.InvalidOperationException.With.Message.EqualTo("The collection is empty!"));
        }

        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Fetch_Should_Return_Copy_Of_Data(int[] expectedData)
        {
            this.database = new Database(expectedData);

            //Returned copy
            int[] actualdata = this.database.Fetch();

            CollectionAssert.AreEquivalent(expectedData, actualdata);
        }
    }
}