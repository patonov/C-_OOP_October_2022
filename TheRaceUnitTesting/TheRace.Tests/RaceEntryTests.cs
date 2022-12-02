using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.That(raceEntry, Is.Not.Null);
            Assert.That(raceEntry.Counter, Is.EqualTo(0));
        }


        [Test]
        public void AddDriver_WorksProperly()
        {
            UnitCar unitCar = new UnitCar("Jiguly", 60, 2.50);
            UnitDriver unitDriver = new UnitDriver("Pesho", unitCar);
            RaceEntry raceEntry = new RaceEntry();

            Assert.That(raceEntry.AddDriver(unitDriver), Is.EqualTo("Driver Pesho added in race."));
            Assert.That(raceEntry.Counter, Is.EqualTo(1));
        }

        [Test]
        public void AddDriver_ThrowsInvalidOperationException_WhenDriverIsNull()
        {
            RaceEntry raceEntry = new RaceEntry();

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(null), "Driver cannot be null.");
        }

        [Test]
        public void AddDriver_ThrowsInvalidOperationException_WhenDriverExists()
        {
            UnitCar unitCar = new UnitCar("Jiguly", 60, 2.50);
            UnitDriver unitDriver = new UnitDriver("Pesho", unitCar);
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);

            Assert.Throws<InvalidOperationException>(() => raceEntry.AddDriver(unitDriver), "Driver Pesho is already added.");
        }

        [Test]
        public void CalculateAverageHorsePower_WorksProperly()
        {
            UnitCar unitCar = new UnitCar("Jiguly", 60, 2.50);
            UnitCar unitCar2 = new UnitCar("Moskwich", 50, 3.00);
            UnitCar unitCar3 = new UnitCar("Volga", 70, 3.50);

            UnitDriver unitDriver = new UnitDriver("Pesho", unitCar);
            UnitDriver unitDriver2 = new UnitDriver("Gosho", unitCar2);
            UnitDriver unitDriver3 = new UnitDriver("Sotir", unitCar3);

            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);
            raceEntry.AddDriver(unitDriver2);
            raceEntry.AddDriver(unitDriver3);

            Assert.That(raceEntry.CalculateAverageHorsePower(), Is.EqualTo(60));
        }

        [Test]
        public void CalculateAverageHorsePower_ThrowsInvalidOperationException_WhenInsufficientNumberOfParticipants()
        {
            UnitCar unitCar = new UnitCar("Jiguly", 60, 2.50);
                       
            UnitDriver unitDriver = new UnitDriver("Pesho", unitCar);
                      
            RaceEntry raceEntry = new RaceEntry();
            raceEntry.AddDriver(unitDriver);
                        
            Assert.Throws<InvalidOperationException>(() => raceEntry.CalculateAverageHorsePower(), "The race cannot start with less than 2 participants.");
        }



    }
}