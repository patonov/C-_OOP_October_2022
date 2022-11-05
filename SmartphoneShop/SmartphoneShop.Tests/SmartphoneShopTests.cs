using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor_WorksProperly()
        {
            Shop shop = new Shop(5);

            Assert.That(shop.Capacity, Is.EqualTo(5));
            Assert.That(shop.Count, Is.EqualTo(0));
        }

        [Test]
        public void Ctor_ThrowsArgumentException_WhenCapacityIsBellowZero()
        {
            Assert.Throws<ArgumentException>(() => new Shop(-1), "Invalid capacity.");
        }

        [Test]
        public void Add_WorksProperly()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            shop.Add(smartphone);
            
            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenModelAlreadyExists()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone), "The phone model Ednookia already exist.");
        }

        [Test]
        public void Add_ThrowsInvalidOperationException_WhenCapacityIsAchieved()
        {
            Shop shop = new Shop(1);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            Smartphone smartphone2 = new Smartphone("GSM s shaiba", 100);
            shop.Add(smartphone);

            Assert.Throws<InvalidOperationException>(() => shop.Add(smartphone2), "The shop is full.");
        }

        [Test]
        public void Remove_WorksProperly()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            Smartphone smartphone2 = new Smartphone("GSM s shaiba", 100);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.Remove("Ednookia");

            Assert.That(shop.Count, Is.EqualTo(1));
        }

        [Test]
        public void Remove_ThrowsInvalidOperationException_WhenSmartphoneDoesNotExist()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            Smartphone smartphone2 = new Smartphone("GSM s shaiba", 100);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Hui phone"), "The phone model Hui phone doesn't exist.");
        }

        [Test]
        public void TestPhone_WorksProperly()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            Smartphone smartphone2 = new Smartphone("GSM s shaiba", 100);

            shop.Add(smartphone);
            shop.Add(smartphone2);
            shop.TestPhone("Ednookia", 20);

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(80));
        }

        [Test]
        public void TestPhone_ThrowsInvalidOperationException_WhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            Smartphone smartphone2 = new Smartphone("GSM s shaiba", 100);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("RessProm", 20), "The phone model RessProm doesn't exist.");
        }

        [Test]
        public void TestPhone_ThrowsInvalidOperationException_WhenCurrentChargeIsBellowCurrentUsage()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            Smartphone smartphone2 = new Smartphone("GSM s shaiba", 100);

            shop.Add(smartphone);
            shop.Add(smartphone2);

            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Ednookia", 120), "The phone model Ednookia is low on batery.");
        }

        [Test]
        public void ChargePhone_WorksProperly()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
            
            shop.Add(smartphone);
            shop.TestPhone("Ednookia", 20);
            shop.ChargePhone("Ednookia");

            Assert.That(smartphone.CurrentBateryCharge, Is.EqualTo(100));
        }

        [Test]
        public void ChargePhone_ThrowsInvalidOperationException_WhenPhoneDoesNotExist()
        {
            Shop shop = new Shop(5);
            Smartphone smartphone = new Smartphone("Ednookia", 100);
           
            shop.Add(smartphone);
            
            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("RessProm"), "The phone model RessProm doesn't exist.");
        }
    }
}