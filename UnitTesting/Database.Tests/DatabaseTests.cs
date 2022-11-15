namespace Database.Tests
{    
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        private Database db;

        [SetUp]
        public void Setup()
        {
            this.db = new Database();
        }

        [Test]
        public void Add_ThrowInvalidOperationException_When_CapacityHasBeenExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }
            Assert.Throws<InvalidOperationException>(() => db.Add(666));
        }

        [Test]
        public void Add_IncreseDatabaseCount_When_TheOperationIsValid()
        {
            int n = 10;

            for (int i = 0; i < n; i++)
            {
                db.Add(i);
            }

            Assert.That(db.Count, Is.EqualTo(n));
        }

        [Test]
        public void Fetch_ReturnsCorrectArray_When_ProperlyCalled()
        {
            int element = 222;

            this.db.Add(element);

            int[] elements = this.db.Fetch();

            Assert.IsTrue(elements.Contains(element));
        }

        [Test]
        public void Remove_ThrowsInvalidOperationException_When_DatabaseIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => this.db.Remove());
        }

        [Test]
        public void Remove_DecreasesTheCountOfTheArray_When_ProperlyCalled()
        {
            this.db.Add(1);
            this.db.Add(2);
            this.db.Add(3);

            this.db.Remove();

            Assert.That(this.db.Count, Is.EqualTo(2));

        }

        [Test]
        public void Remove_ElementDesappearedOnDatabase_When_ProperlyRemoved()
        {
            this.db.Add(1);
            this.db.Add(2);
            this.db.Add(3);

            this.db.Remove();

            int[] drawedArr = this.db.Fetch();

            Assert.IsTrue(!drawedArr.Contains(3));

        }
    }
}
