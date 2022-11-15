
namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new Database();
        }

        [Test]
        public void Add_ThrowsException_WhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"Username{i}"));
            }

            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Add(new Person(16, "InvalidUsername")));
        }

        [Test]
        public void Add_ThrowsException_WhenUsernameIsUsed()
        {
            string username = "Nasko";

            this.extendedDatabase.Add(new Person(1, username));

            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Add(new Person(2, username)));
        }

        [Test]
        public void Add_ThrowsException_WhenIdIsUsed()
        {
            long id = 1;

            this.extendedDatabase.Add(new Person(id, "RandomUser"));

            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Add(new Person(id, "RandomUser2")));
        }

        [Test]
        public void Add_IncreasesCounter_WhenUserIsValid()
        {
            this.extendedDatabase.Add(new Person(1, "Pesho"));
            this.extendedDatabase.Add(new Person(2, "Gosho"));

            int expectedCount = 2;

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Remove_ThrowsException_WhenDatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            this.extendedDatabase.Remove());
        }

        [Test]
        public void Remove_RemovesElementFromDatabase()
        {
            int n = 5;

            for (int i = 0; i < n; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"User{i}"));
            }

            this.extendedDatabase.Remove();

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(n - 1));
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(n - 1));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsername_ThrowsException_WhenArgumentIsNotValid(string username)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(username));

        }

        [Test]
        public void FindByUsername_ThrowsException_UsernameDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername("Username"));

        }

        [Test]
        public void FindByUsername_ReturnExpectedUser_WhenUserExists()
        {
            Person person = new Person(1, "Pesho");

            this.extendedDatabase.Add(person);

            Person dbPerson = this.extendedDatabase.FindByUsername(person.UserName);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-25)]
        public void FindById_ThrowsException_WhenIdIsLessThanZero(long id)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(id));
        }

        [Test]
        public void FindById_ThrowsException_WhenIdDoesNotExist()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(100));
        }

        [Test]
        public void FindById_ReturnsExpectedPerson_WhenPersonWithIdExist()
        {
            Person person = new Person(1, "Putio");

            this.extendedDatabase.Add(person);

            Person dbPerson = this.extendedDatabase.FindById(person.Id);

            Assert.That(person, Is.EqualTo(dbPerson));
        }

        [Test]
        public void Ctor_ThrowsException_WhenCapacityIsExceeded()
        {
            Person[] arguments = new Person[17];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"User{i}");
            }

            Assert.Throws<ArgumentException>(() => this.extendedDatabase
            = new Database(arguments));
        }

        [Test]
        public void Ctor_AddInitialPeopleToDatabase()
        {
            Person[] arguments = new Person[5];

            for (int i = 0; i < arguments.Length; i++)
            {
                arguments[i] = new Person(i, $"User{i}");
            }

            this.extendedDatabase = new Database(arguments);

            Assert.That(this.extendedDatabase.Count, Is.EqualTo(arguments.Length));

            foreach (var person in arguments)
            {
                Person dbPerson = this.extendedDatabase.FindById(person.Id);

                Assert.That(person, Is.EqualTo(dbPerson));
            }

        }
    }
}