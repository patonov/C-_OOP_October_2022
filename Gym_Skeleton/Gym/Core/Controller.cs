using Gym.Core.Contracts;
using Gym.Repositories;
using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Gyms.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Equipment;
using System.Linq;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Athletes;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipmentRepository;
        private List<IGym> gyms;

        public Controller()
        {
            this.equipmentRepository = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if (athleteType != "Boxer" && athleteType != "Weightlifter")
            {
                throw new InvalidOperationException("Invalid athlete type.");
            }

            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            if (!gym.GetType().Name.StartsWith(athleteType.Substring(0, 3)))
            {
                return "The gym is not appropriate.";
            }

            IAthlete athlete;
            if (athleteType == "Boxer")
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else
            { 
            athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            gym.AddAthlete(athlete);
            return $"Successfully added {athleteType} to {gymName}.";
        }

        public string AddEquipment(string equipmentType)
        {
            if (equipmentType != "BoxingGloves" && equipmentType != "Kettlebell")
            {
                throw new InvalidOperationException("Invalid equipment type.");
            }
            IEquipment equ;

            if (equipmentType == "BoxingGloves")
            {
                equ = new BoxingGloves();
            }
            else
            {
                equ = new Kettlebell();
            }

            this.equipmentRepository.Add(equ);
            return $"Successfully added {equ.GetType().Name}.";
        }

        public string AddGym(string gymType, string gymName)
        {
            if (gymType != "BoxingGym" && gymType != "WeightliftingGym")
            {
                throw new InvalidOperationException("Invalid gym type."); 
            }
            IGym gym;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }
            this.gyms.Add(gym);
            return $"Successfully added {gym.GetType().Name}.";
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            return $"The total weight of the equipment in the gym {gymName} is {(gym.EquipmentWeight):f2} grams.";
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            IEquipment equ = this.equipmentRepository.FindByType(equipmentType);
            if (equ == null)
            {
                throw new InvalidOperationException($"There isn’t equipment of type {equipmentType}.");
            }
            gym.AddEquipment(equ);

            this.equipmentRepository.Remove(equ);

            return $"Successfully added {equipmentType} to {gymName}.";
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();
            return $"Exercise athletes: {gym.Athletes.Count}.";
        }
    }
}
