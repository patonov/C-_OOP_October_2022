using NUnit.Framework;
using System;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            ComputerManager cManager = new ComputerManager();

            Assert.That(cManager, Is.Not.Null);
            Assert.That(cManager.Count, Is.EqualTo(0));
        }

        [Test]
        public void AddComputer_WorksProperly()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            cManager.AddComputer(computer);

            var computerFound = cManager.Computers.FirstOrDefault(x => x.Model == "BashPravets");

            Assert.That(computer, Is.Not.Null);
            Assert.That(cManager.Count, Is.EqualTo(1));
            Assert.That(computerFound, Is.Not.Null);
        }

        [Test]
        public void AddComputer_ThrowsArgumentNullException_WhenComputerIsNull()
        {
            ComputerManager cManager = new ComputerManager();
            Assert.Throws<ArgumentNullException>(()=> cManager.AddComputer(null), "Can not be null!");
        }

        [Test]
        public void AddComputer_ThrowsArgumentException_WhenComputerAlreadyExists()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            cManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => cManager.AddComputer(computer), "This computer already exists.");
        }

        [Test]
        public void RemoveComputer_WorksProperly()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            cManager.AddComputer(computer);
            Computer compToRemove = computer;

            Assert.That(cManager.RemoveComputer("Zavod Pravets", "BashPravets"), Is.EqualTo(compToRemove));
        }

        [Test]
        public void RemoveComputer_ThrowsArgumentException_WhenNoComputerToRemove()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            cManager.AddComputer(computer);
            
            Assert.Throws<ArgumentException>(()=> cManager.RemoveComputer("Zavoda", "Borovets"), 
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputer_WorksProperly()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            cManager.AddComputer(computer);

            Assert.That(cManager.GetComputer("Zavod Pravets", "BashPravets"), Is.EqualTo(computer));
        }

        [Test]
        public void GetComputer_ThrowsArgumentException_WhenNoComputerToGet()
        {
            ComputerManager cManager = new ComputerManager();

            Assert.Throws<ArgumentException>(() => cManager.RemoveComputer("Zavoda", "Borovets"),
                "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputer_ThrowsArgumentNullException_WhenNoComputerWithPropertiesRequired()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            cManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => cManager.RemoveComputer(null, "BashPravets"),
                "Can not be null!");
            Assert.Throws<ArgumentNullException>(() => cManager.RemoveComputer("Zavod Pravets", null),
                "Can not be null!");
        }

        [Test]
        public void GetComputersByManufacturer_WorksProperly()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer1 = new Computer("Zavod Pravets", "BashPravets", 1000m);
            Computer computer2 = new Computer("Zavod Pravets", "Pulna Toyaga", 1002m);

            cManager.AddComputer(computer1);
            cManager.AddComputer(computer2);

            var compsOfZavodPravets = cManager.GetComputersByManufacturer("Zavod Pravets");

            Assert.That(compsOfZavodPravets.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowsArgumentNullExpection_WhenNoSuchManufactturer()
        {
            ComputerManager cManager = new ComputerManager();
            Computer computer = new Computer("Zavod Pravets", "BashPravets", 1000m);
            
            cManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(()=> cManager.GetComputersByManufacturer(null), "Can not be null!");
        }
    }
}