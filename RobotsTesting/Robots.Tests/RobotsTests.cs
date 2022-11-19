namespace Robots.Tests
{
    using NUnit.Framework;
    using System;
    using Robots;

    public class RobotsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            RobotManager manager = new RobotManager(3);

            Assert.IsNotNull(manager);
            Assert.That(manager.Capacity, Is.EqualTo(3));
            Assert.That(manager.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenCapacityIsLessThanZero()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1), "Invalid capacity!");
        }

        [Test]
        public void Add_WorksProperly()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Pesho", 14);

            manager.Add(robot);
            Assert.That(manager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenRobotAlreadyExists()
        {
            RobotManager manager = new RobotManager(3);
            Robot robot = new Robot("Pesho", 14);

            manager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot), "There is already a robot with name Pesho!");
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenCapacityIsAcieved()
        {
            RobotManager manager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 14);
            Robot robot2 = new Robot("Mitko", 11);
            Robot robot3 = new Robot("Gosho", 14);

            manager.Add(robot);
            manager.Add(robot2);

            Assert.Throws<InvalidOperationException>(() => manager.Add(robot3), "Not enough capacity!");
        }

        [Test]
        public void Remove_WorksProperly()
        {
            RobotManager manager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 14);
            Robot robot2 = new Robot("Mitko", 11);

            manager.Add(robot);
            manager.Add(robot2);

            manager.Remove("Pesho");

            Assert.That(manager.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ThrowsInvalidOperationException_WhenRobotDoesNotExist()
        {
            RobotManager manager = new RobotManager(2);

            Assert.Throws<InvalidOperationException>(() => manager.Remove("Ivan"), "Robot with the name Ivan doesn't exist!");
        }

        [Test]
        public void Work_TheMethodWorksCorrectly()
        {
            RobotManager manager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 14);
            Robot robot2 = new Robot("Mitko", 11);

            manager.Add(robot);
            manager.Add(robot2);

            manager.Work("Pesho", "Programmer", 3);

            Assert.That(robot.Battery, Is.EqualTo(11));
        }

        [Test]
        public void Work_TheMethodThrowsInvalidOperationException_WhenRobotDoesNotExist()
        {
            RobotManager manager = new RobotManager(2);
            Assert.Throws<InvalidOperationException>(() => manager.Work("Pesho", "Programmer", 3), "Robot with the name Pesho doesn't exist!");
        }

        [Test]
        public void Work_TheMethodThrowsInvalidOperationException_WhenRobotDoesNotHaveEnoughBattery()
        {
            RobotManager manager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 5);

            Assert.Throws<InvalidOperationException>(() => manager.Work("Pesho", "Programmer", 7), "Pesho doesn't have enough battery!");
        }

        [Test]
        public void Charge_WorksProperly()
        {
            RobotManager manager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 5);

            manager.Add(robot);

            manager.Work("Pesho", "Programmer", 2);

            manager.Charge("Pesho");

            Assert.That(robot.Battery, Is.EqualTo(5));
        }

        [Test]
        public void Charge_ThrowsInvalidOperationException_WhenRobotDoesNotExist()
        {
            RobotManager manager = new RobotManager(2);
            Robot robot = new Robot("Pesho", 5);

            manager.Add(robot);
                        
            Assert.Throws<InvalidOperationException>(() => manager.Charge("Mitko"), "Robot with the name Mitko doesn't exist!");
        }

        [Test]
        public void Ctor_CreatesRobotSuccessfully()
        {
            Robot robot = new Robot("Pesho", 14);

            Assert.That(robot.Name, Is.EqualTo("Pesho"));
            Assert.That(robot.MaximumBattery, Is.EqualTo(14));
            Assert.That(robot.Battery, Is.EqualTo(14));
        }

    }
}
