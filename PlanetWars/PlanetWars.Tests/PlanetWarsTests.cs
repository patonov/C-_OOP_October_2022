using NUnit.Framework;
using System;

namespace PlanetWars.Tests
{
    public class Tests
    {
        [TestFixture]
        public class PlanetWarsTests
        {
            
            [Test]
            public void Ctor_SetsNameAndBudgetProperly()
            {
                string name = "Mars";
                double budget = 10000;

                Planet planet = new Planet("Mars", 10000);

                Assert.That(planet.Name, Is.EqualTo(name));
                Assert.That(planet.Budget, Is.EqualTo(budget));
                Assert.That(planet.MilitaryPowerRatio, Is.EqualTo(0));
            }

            [Test]
            public void Ctor_ThrowsArgumentException_WhenNameIsNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() => new Planet(null, 10000), "Invalid planet Name");
                Assert.Throws<ArgumentException>(() => new Planet("", 10000), "Invalid planet Name");
            }

            [Test]
            public void Ctor_CreatesCollectionProperly()
            {
                Planet planet = new Planet("Mars", 10000);
                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }

            [Test]
            public void Ctor_ThrowsArgumentException_WhenBudgetIsNegativeValue()
            {
                Assert.Throws<ArgumentException>(() => new Planet("Mars", -1), "Budget cannot drop below Zero!");                
            }

            [Test]
            public void Ctor_Weapon_Correctly_CreatesNewWeapon()
            {
                var weapon = new Weapon("Nuclear", 120, 9);

                Assert.That(weapon.DestructionLevel, Is.EqualTo(9));
                Assert.That(weapon.Price, Is.EqualTo(120));
                Assert.That(weapon.Name, Is.EqualTo("Nuclear"));
            }

            [Test]
            public void AddWeapon_AddsWeapon_WhenTheParametersAreCorrect()
            {
                Planet planet = new Planet("Mars", 10000);
                Weapon weapon = new Weapon("Gun", 130, 8);
                planet.AddWeapon(weapon);
                Assert.That(planet.Weapons.Count, Is.EqualTo(1));
            }

            [Test]
            public void AddWeapon_NoWeaponAdded_WhenWeaponIsRepeated()
            {
                Planet planet = new Planet("Mars", 10000);
                Weapon weapon = new Weapon("Gun", 130, 8);
                Weapon weapon2 = new Weapon("Gun", 11, 2);
                planet.AddWeapon(weapon);

                Assert.Throws<InvalidOperationException>(() => planet.AddWeapon(weapon2), $"There is already a {weapon2.Name} weapon.");
            }

            [Test]
            public void RemoveWeapon_WhenItWorksProperly()
            {
                Planet planet = new Planet("Mars", 10000);
                Weapon weapon = new Weapon("Gun", 130, 8);
                
                planet.AddWeapon(weapon);
                
                planet.RemoveWeapon("Gun");

                Assert.That(planet.Weapons.Count, Is.EqualTo(0));
            }
                       
            [Test]
            public void UpgradeWeapon_ThrowsInvalidOperationException_WhenWeaponDoesNotExists()
            {
                Planet planet = new Planet("Mars", 10000);
                
                Assert.Throws<InvalidOperationException>(() => planet.UpgradeWeapon("Makarov"), $"Makarov does not exist in the weapon repository of {planet.Name}");
            }

            [Test]
            public void UpgradeWeapon_WhenItWorksProperly()
            {
                Planet planet = new Planet("Mars", 10000);
                Weapon weapon = new Weapon("Gun", 130, 8);

                planet.AddWeapon(weapon);

                int expectedDistructionPower = 9;
                planet.UpgradeWeapon("Gun");

                Assert.That(weapon.DestructionLevel, Is.EqualTo(expectedDistructionPower));
            }

            [Test]
            public void DestructOpponent_Throws_IfOpponentIsTooStrong()
            {
                var planetOne = new Planet("PlanetOne", 1500);
                var planetTwo = new Planet("PlanetTwo", 2000);

                var weaponOne = new Weapon("WeaponOne", 20, 2);
                var weaponTwo = new Weapon("WeaponTwo", 30, 5);
                var weaponThree = new Weapon("WeaponThree", 20, 2);


                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);
                planetTwo.AddWeapon(weaponTwo);

                Assert.Throws<InvalidOperationException>(() => planetOne.DestructOpponent(planetTwo),
                    "planetTwo is too strong to declare war to!");
            }

            [Test]
            public void DestructOpponent_WorksProperly()
            {
                var planetOne = new Planet("PlanetOne", 1500);
                var planetTwo = new Planet("PlanetTwo", 2000);

                var weaponOne = new Weapon("WeaponOne", 20, 2);
                var weaponTwo = new Weapon("WeaponTwo", 30, 5);
                var weaponThree = new Weapon("WeaponThree", 20, 4);


                planetOne.AddWeapon(weaponOne);
                planetOne.AddWeapon(weaponThree);
                planetTwo.AddWeapon(weaponTwo);

                var expectedResult = "PlanetTwo is destructed!";

                Assert.That(planetOne.DestructOpponent(planetTwo), Is.EqualTo(expectedResult));
            }

            [Test]
            public void Weapon_PriceCannotBeNagative()
            {
                Assert.Throws<ArgumentException>(() => new Weapon("Weapon", -5, 8), "Price can not be negative.");
            }
        }

    }
}
