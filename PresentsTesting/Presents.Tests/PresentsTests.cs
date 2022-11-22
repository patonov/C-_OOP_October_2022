namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            Bag bag = new Bag();
            Assert.That(bag, Is.Not.Null);
        }

        [Test]
        public void Ctor_PresentWorksProperly()
        {
            Present present = new Present("Toy", 22.1);
            Assert.That(present, Is.Not.Null);
        }

        [Test]
        public void Create_WorksProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 22.1);
            Assert.That(bag.Create(present), Is.EqualTo($"Successfully added present {present.Name}."));
            Assert.That(bag.GetPresents().Count, Is.EqualTo(1));
            Assert.That(bag.GetPresent("Toy"), Is.EqualTo(present));
        }

        [Test]
        public void Create_ThrowsArgumentNullException_WhenPresentIsNull()
        {
            Bag bag = new Bag();
            Assert.Throws<ArgumentNullException>(()=> bag.Create(null), "Present is null");
        }

        [Test]
        public void Create_ThrowsInvalidOperationException_WhenPresentAlreadyExists()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 22.1);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(()=> bag.Create(present), "This present already exists!");
        }

        [Test]
        public void Remove_WorksProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 22.1);
            bag.Create(present);
            Assert.That(bag.Remove(present), Is.True);
        }

        [Test]
        public void GetPresentWithLeastMagic_WorksProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 22.1);
            Present present2 = new Present("Car", 2.1);
            Present present3 = new Present("Truck", 8.1);
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Present returnedPresent = bag.GetPresentWithLeastMagic();
            Assert.That(returnedPresent, Is.EqualTo(present2));
        }
        
        [Test]
        public void GetPresent_WorksProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 22.1);
            Present present2 = new Present("Car", 2.1);
            Present present3 = new Present("Truck", 8.1);
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Present returnedPresent = bag.GetPresent("Car");
            Assert.That(returnedPresent, Is.EqualTo(present2));
        }

        [Test]
        public void GetPresents_WorksProperly()
        {
            Bag bag = new Bag();
            Present present = new Present("Toy", 22.1);
            Present present2 = new Present("Car", 2.1);
            Present present3 = new Present("Truck", 8.1);
            bag.Create(present);
            bag.Create(present2);
            bag.Create(present3);

            Assert.That(bag.GetPresents().Count, Is.EqualTo(3));
        }

    }
}
