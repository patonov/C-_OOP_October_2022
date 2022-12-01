using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private DriverRepository driverRepository;
        private CarRepository carRepository;
        private RaceRepository raceRepository;

        public ChampionshipController()
        {
            this.driverRepository = new DriverRepository();
            this.carRepository = new CarRepository();
            this.raceRepository = new RaceRepository();
        }
            

        public string AddCarToDriver(string driverName, string carModel)
        {
            IDriver targetDriver = this.driverRepository.GetByName(driverName);
            ICar targetCar = this.carRepository.GetByName(carModel);

            if (targetDriver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (targetCar == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            targetDriver.AddCar(targetCar);
            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            IDriver driver = this.driverRepository.GetByName(driverName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);
            return $"Driver {driver.Name} added in {race.Name} race.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            if (this.carRepository.GetByName(model) != null)
            {
                throw new ArgumentException($"Car {model} is already created.");
            }

            ICar car;

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }            
            else
            {
                car = new SportsCar(model, horsePower);
            }
            this.carRepository.Add(car);
            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var askedDriver = this.driverRepository.GetByName(driverName);
            if (askedDriver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            IDriver driver = new Driver(driverName);
            this.driverRepository.Add(driver);

            return $"Driver {driver.Name} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            if (this.raceRepository.GetByName(name) != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            IRace race = new Race(name, laps);
            this.raceRepository.Add(race);
            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            IRace race = this.raceRepository.GetByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }
            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {race.Name} cannot start with less than 3 participants.");
            }
            var finishers = race.Drivers.OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps)).ToList();

            StringBuilder sb = new StringBuilder();
                        
            sb.AppendLine($"Driver {finishers[0].Name} wins {race.Name} race.");
            sb.AppendLine($"Driver {finishers[1].Name} is second in {race.Name} race.");
            sb.AppendLine($"Driver {finishers[2].Name} is third in {race.Name} race.");

            return sb.ToString().Trim();
        }
    }
}
