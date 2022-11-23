namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;
    
    [TestFixture]
    public class AquariumsTests
    {
        [SetUp]
        public void Setup()
        {        
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 200);

            Assert.That(aquarium, Is.Not.Null);
            Assert.That(aquarium.Name, Is.EqualTo("Aqua"));
            Assert.That(aquarium.Capacity, Is.EqualTo(200));
            Assert.That(aquarium.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsArgumentNullException_WhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(()=> new Aquarium(null, 20), "Invalid aquarium name!");
            Assert.Throws<ArgumentNullException>(() => new Aquarium("", 20), "Invalid aquarium name!");
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenCapacityIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("VarnaAqua", -1), "Invalid aquarium capacity!");
        }

        [Test]
        public void Count_ReturnsAllTheFishesCorrectly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 200);
            Fish gupa = new Fish("Gupa");
            Fish heiler = new Fish("Heiler");

            aquarium.Add(gupa);
            aquarium.Add(heiler);
            Assert.That(aquarium.Count, Is.EqualTo(2));
        }

        [Test]
        public void Add_TheMethodAddsFishProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 200);
            Fish gupa = new Fish("Gupa");
            aquarium.Add(gupa);
            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenCapacityIsAchieved()
        {
            Aquarium aquarium = new Aquarium("Aqua", 1);
            Fish gupa = new Fish("Gupa");
            Fish heiler = new Fish("Heiler");
            aquarium.Add(gupa);
            Assert.Throws<InvalidOperationException>(()=> aquarium.Add(heiler), "Aquarium is full!");
        }

        [Test]
        public void RemoveFish_WorksProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 3);
            Fish gupa = new Fish("Gupa");
            Fish heiler = new Fish("Heiler");
            aquarium.Add(gupa);
            aquarium.Add(heiler);
            aquarium.RemoveFish("Gupa");

            Assert.That(aquarium.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveFish_ThrowsInvalidOperationException_WhenFishDoesNotExist()
        {
            Aquarium aquarium = new Aquarium("Aqua", 3);
            Assert.Throws<InvalidOperationException>(()=> aquarium.RemoveFish("Pesho"), "Fish with the name Pesho doesn't exist!");
        }

        [Test]
        public void SellFish_WorksProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 3);
            Fish gupa = new Fish("Gupa");
            Fish heiler = new Fish("Heiler");
            aquarium.Add(gupa);
            aquarium.Add(heiler);

            Assert.That(aquarium.SellFish("Gupa"), Is.EqualTo(gupa));
            Assert.That(gupa.Available, Is.False);
        }

        [Test]
        public void SellFish_ThrowsInvalidOperationException_WhenFishDoesNotExist()
        {
            Aquarium aquarium = new Aquarium("Aqua", 3);
            Assert.Throws<InvalidOperationException>(()=> aquarium.SellFish("Pesho"), "Fish with the name Pesho doesn't exist!");
        }

        [Test]
        public void Report_WorksProperly()
        {
            Aquarium aquarium = new Aquarium("Aqua", 3);
            Fish gupa = new Fish("Gupa");
            Fish heiler = new Fish("Heiler");
            aquarium.Add(gupa);
            aquarium.Add(heiler);

            string result = "Fish available at Aqua: Gupa, Heiler";
            Assert.That(aquarium.Report, Is.EqualTo(result));
        }


    }
}
