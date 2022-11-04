using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;

        public Controller()    
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.carRepository = new FormulaOneCarRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.FindByName(pilotName);
            if (pilot == null || pilot.CanRace == true)
            {
                throw new InvalidOperationException($"Pilot { pilotName } does not exist or has a car.");
            }

            var car = this.carRepository.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException($"Car { carModel } does not exist.");
            }
            pilot.AddCar(car);
            this.carRepository.Remove(car);
            return $"Pilot { pilotName } will drive a {car.GetType().Name} { carModel } car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }

            var pilot = this.pilotRepository.FindByName(pilotFullName);
            if (pilot == null || pilot.CanRace == false)
            {
                throw new InvalidOperationException($"Can not add pilot { pilotFullName } to the race.");
            }
            race.AddPilot(pilot);
            return $"Pilot { pilotFullName } is added to the { raceName } race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            if (type != nameof(Ferrari) && type != nameof(Williams))
            {
                throw new InvalidOperationException($"Formula one car type { type } is not valid.");
            }

            IFormulaOneCar car;
            if (type == nameof(Ferrari))
            {
                car = new Ferrari(model, horsepower, engineDisplacement);
            }
            else
            {
                car = new Williams(model, horsepower, engineDisplacement);
            }
            if (this.carRepository.FindByName(model) != null)
            {
                throw new InvalidOperationException($"Formula one car { model } is already created.");
            }
            this.carRepository.Add(car);
            return $"Car { type }, model { model } is created.";
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = new Pilot(fullName);
            if (this.pilotRepository.FindByName(fullName) != null)
            {
                throw new InvalidOperationException($"Pilot { fullName } is already created.");
            }
            this.pilotRepository.Add(pilot);
            return $"Pilot { fullName } is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = new Race(raceName, numberOfLaps);
            if (this.raceRepository.FindByName(raceName) != null)
            {
                throw new InvalidOperationException($"Race { raceName } is already created.");
            }
            this.raceRepository.Add(race);
            return $"Race { raceName } is created.";
        }

        public string PilotReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var p in pilotRepository.Models)
            {
                sb.AppendLine($"Pilot {p.FullName} has {p.NumberOfWins} wins.");
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var r in raceRepository.Models)
            { 
            sb.AppendLine(r.RaceInfo());
            }
            return sb.ToString().Trim();
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException($"Race { raceName } does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race { raceName } cannot start with less than three participants.");
            }

            if (race.TookPlace == true)
            {
                throw new InvalidOperationException($"Can not execute race { raceName }.");
            }

            var riders = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps));
            race.TookPlace = true;
            var winner = riders.FirstOrDefault();
            winner.WinRace();

            return $"Pilot { winner.FullName } wins the { race.RaceName } race.";
        }
    }
}
