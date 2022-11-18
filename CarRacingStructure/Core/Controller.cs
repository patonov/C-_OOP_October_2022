using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Models.Racers;

namespace CarRacing.Core.Contracts
{
    public class Controller : IController
    {
        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            this.cars = new CarRepository();
            this.racers = new RacerRepository();
            this.map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type != "SuperCar" && type != "TunedCar")
            {
                throw new ArgumentException("Invalid car type!");
            }

            ICar car = default;

            if (type == nameof(TunedCar))
            {
                car = new TunedCar(make, model, VIN, horsePower);
            }
            else
            {
                car = new SuperCar(make, model, VIN, horsePower);
            }

            this.cars.Add(car);

            return $"Successfully added car {car.Make} {car.Model} ({car.VIN}).";
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if (type != "ProfessionalRacer" && type != "StreetRacer")
            {
                throw new ArgumentException("Invalid racer type!");
            }

            ICar car = this.cars.Models.FirstOrDefault(x => x.VIN == carVIN);

            if (car == null)
            {
                throw new ArgumentException("Car cannot be found!");
            }

            IRacer racer;

            if (type == nameof(ProfessionalRacer))
            {
                racer = new ProfessionalRacer(username, car);
            }
            else
            {
                racer = new StreetRacer(username, car);
            }

            this.racers.Add(racer);
            return $"Successfully added racer {racer.Username}.";
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            IRacer racerOne = this.racers.Models.FirstOrDefault(x => x.Username == racerOneUsername);
            IRacer racerTwo = this.racers.Models.FirstOrDefault(x => x.Username == racerTwoUsername);

            if (racerOne == null)
            {
                throw new ArgumentException($"Racer {racerOneUsername} cannot be found!");
            }

            if (racerTwo == null)
            {
                throw new ArgumentException($"Racer {racerTwoUsername} cannot be found!");
            }

            return map.StartRace(racerOne, racerTwo);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (IRacer racer in this.racers.Models)
            {
                sb.AppendLine($"{racer.GetType()}: {racer.Username}");
                sb.AppendLine($"--Driving behavior: {racer.RacingBehavior}");
                sb.AppendLine($"--Driving experience: {racer.DrivingExperience}");
                sb.AppendLine($"--Car: {racer.Car.Make} {racer.Car.Model} ({racer.Car.VIN})");
            }
            return sb.ToString().Trim();
        }
    }
}
