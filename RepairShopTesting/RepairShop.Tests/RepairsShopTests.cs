using NUnit.Framework;
using System;
using System.Linq;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [SetUp]
            public void Setup()
            {

            }

            [Test]
            public void Ctor_WorksProperly()
            {
                var garage = new Garage("Ela pri Nas", 4);

                string expectedName = "Ela pri Nas";
                int expectedAvailableMechanics = 4;

                Assert.That(garage.Name, Is.EqualTo(expectedName));
                Assert.That(garage.MechanicsAvailable, Is.EqualTo(expectedAvailableMechanics));
                Assert.That(garage.CarsInGarage, Is.EqualTo(0));
            }

            [Test]
            public void Ctor_ThrowsArgumentNullException_WhenNameIsNullOrEmpty()
            {
                Assert.Throws<ArgumentNullException>(() => new Garage("", 4), "Invalid garage name.");
                Assert.Throws<ArgumentNullException>(() => new Garage(null, 4), "Invalid garage name.");
            }

            [Test]
            public void Ctor_ThrowsArgumentException_WhenAvailableMechanicsAreZeroOrLess()
            {
                Assert.Throws<ArgumentException>(() => new Garage("Mama Vi Mrusna", 0), "At least one mechanic must work in the garage.");
                Assert.Throws<ArgumentException>(() => new Garage("Mama Vi Mrusna", -1), "At least one mechanic must work in the garage.");
            }

            [Test]
            public void AddCar_WorksCorrectly()
            {
                var garage = new Garage("Free Ebane", 2);
                var car = new Car("Moskvich", 4);

                garage.AddCar(car);

                Assert.That(garage.CarsInGarage, Is.EqualTo(1));
            }

            [Test]
            public void AddCar_ThrowsInvalidOperationException_WhenNoAvailableMechanics()
            {
                var garage = new Garage("Free Ebane", 2);
                var car1 = new Car("Moskvich", 4);
                var car2 = new Car("Jiguli", 6);
                var car3 = new Car("Polski Fiat", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);
                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car3));
            }

            [Test]
            public void FixCar_WorksCorrectly()
            {
                var garage = new Garage("Free Ebane", 6);
                var car1 = new Car("Moskvich", 4);
                var car2 = new Car("Jiguli", 1);
                var car3 = new Car("Polski Fiat", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                string modelOfCarToFix = "Jiguli";

                Assert.That(garage.FixCar(modelOfCarToFix), Is.EqualTo(car2));
                Assert.That(car2.NumberOfIssues, Is.EqualTo(0));
                Assert.That(car2.IsFixed, Is.True);
            }

            [Test]
            public void FixCar_ThrowsInvalidOperationException_WhenCarToFixIsNull()
            {
                var garage = new Garage("Free Ebane", 6);
                var car1 = new Car("Moskvich", 4);
                var car2 = new Car("Jiguli", 1);
                var car3 = new Car("Polski Fiat", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                string modelOfCarToFix = "BMW";

                Assert.Throws<InvalidOperationException>(() => garage.FixCar(modelOfCarToFix), $"The car {modelOfCarToFix} doesn't exist.");
            }

            [Test]
            public void RemoveFixedCar_WorksProperly()
            {
                var garage = new Garage("Free Ebane", 6);
                var car1 = new Car("Moskvich", 4);
                var car2 = new Car("Jiguli", 1);
                var car3 = new Car("Polski Fiat", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                string modelOfCarToFix = "Jiguli";
                garage.FixCar(modelOfCarToFix);

                Assert.That(garage.RemoveFixedCar, Is.EqualTo(1));
            }
            
            [Test]
            public void RemoveFixedCar_ThrowsArgumentException_WhenNoCarsFixed()
            {
                var garage = new Garage("Free Ebane", 6);
                var car1 = new Car("Moskvich", 4);
                var car2 = new Car("Jiguli", 1);
                garage.AddCar(car1);
                garage.AddCar(car2);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar(), "No fixed cars available.");
            }

            [Test]
            public void Report_WorksProperly()
            {
                var garage = new Garage("Free Ebane", 6);
                var car1 = new Car("Moskvich", 4);
                var car2 = new Car("Jiguli", 1);
                garage.AddCar(car1);
                garage.AddCar(car2);

                string report = "There are 2 which are not fixed: Moskvich, Jiguli.";
                Assert.That(garage.Report(), Is.EqualTo(report));
            }

        }
    }
}