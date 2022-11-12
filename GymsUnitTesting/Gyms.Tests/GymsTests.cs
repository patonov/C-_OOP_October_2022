using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            Gym gym = new Gym("Trenirovka", 22);

            Assert.That(gym.Name, Is.EqualTo("Trenirovka"));
            Assert.That(gym.Capacity, Is.EqualTo(22));
            Assert.That(gym.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsArgumentNullException_WhenNameIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() => new Gym("", 22), "Invalid gym name.");
            Assert.Throws<ArgumentNullException>(() => new Gym(null, 22), "Invalid gym name.");
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenCapacityIsBelowZero()
        {
            Assert.Throws<ArgumentException>(() => new Gym("AtanasGyma", -1), "Invalid gym capacity.");
        }

        [Test]
        public void AddAthlete_WorksProperly()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Gym gym = new Gym("Trenirovka", 22);

            gym.AddAthlete(athlete);
            
            Assert.That(gym.Count, Is.EqualTo(1));
        }

        [Test]
        public void AddAthlete_ThrowsInvalidOperationException_WhenGymCountIsEqualToGymCapacity()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Athlete athleteSecond = new Athlete("Mitio Krika");
            
            Gym gym = new Gym("Trenirovka", 1);
            gym.AddAthlete(athlete);

            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athleteSecond), "The gym is full.");
        }

        [Test]
        public void RemoveAthlete_WorksProperly()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Athlete athleteSecond = new Athlete("Mitio Krika");

            Gym gym = new Gym("Trenirovka", 2);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athleteSecond);

            gym.RemoveAthlete("Mitio Krika");

            Assert.That(gym.Count, Is.EqualTo(1));
        }

        [Test]
        public void RemoveAthlete_ThrowsInvalidOperationException_WhenTheNameOfAthleteIsInvalid()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Athlete athleteSecond = new Athlete("Mitio Krika");

            Gym gym = new Gym("Trenirovka", 2);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athleteSecond);
            
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Kiro Shtangata"), "The athlete Kiro Shtangata doesn't exist.");
        }

        [Test]
        public void InjureAthlete_WorksProperly()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Athlete athleteSecond = new Athlete("Mitio Krika");

            Gym gym = new Gym("Trenirovka", 2);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athleteSecond);

            gym.InjureAthlete("Pesho Atleta");

            Assert.That(athlete.IsInjured, Is.True);
        }

        [Test]
        public void InjureAthlete_ThrowsInvalidOperationException_WhenTheAthleteDoesNotExist()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Athlete athleteSecond = new Athlete("Mitio Krika");

            Gym gym = new Gym("Trenirovka", 2);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athleteSecond);

            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Kiro Sexa"), "The athlete Kiro Sexa doesn't exist.");
        }

        [Test]
        public void Report_WorksProperly()
        {
            Athlete athlete = new Athlete("Pesho Atleta");
            Athlete athleteSecond = new Athlete("Mitio Krika");
            Athlete athleteThird = new Athlete("Bash Motikata");

            Gym gym = new Gym("Trenirovka", 4);
            gym.AddAthlete(athlete);
            gym.AddAthlete(athleteSecond);
            gym.AddAthlete(athleteThird);
            gym.InjureAthlete("Bash Motikata");

            string result = "Active athletes at Trenirovka: Pesho Atleta, Mitio Krika";

            Assert.That(gym.Report, Is.EqualTo(result));
        }
    }
}
