using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;

        public Controller()
        {
            this.gyms = new HashSet<IGym>();
            this.equipment = new EquipmentRepository();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            var gymToAdd = gyms.FirstOrDefault(x => x.Name == gymName);
            IAthlete athlet = athleteType switch
            {
                nameof(Boxer) => new Boxer(athleteName, motivation, numberOfMedals),
                nameof(Weightlifter) => new Weightlifter(athleteName, motivation, numberOfMedals),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType)
            };
            if (athleteType == "Boxer")
            {
                if (gymToAdd.GetType().Name == nameof(WeightliftingGym))
                {
                    return OutputMessages.InappropriateGym;
                }
                gymToAdd.AddAthlete(athlet);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }
            else
            {
                if (gymToAdd.GetType().Name == nameof(BoxingGym))
                {
                    return OutputMessages.InappropriateGym;
                }
                gymToAdd.AddAthlete(athlet);
                return String.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            }

        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentToAdd = equipmentType switch
            {
                nameof(BoxingGloves) => new BoxingGloves(),
                nameof(Kettlebell) => new Kettlebell(),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType)
            };
            equipment.Add(equipmentToAdd);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = gymType switch
            {
                nameof(BoxingGym) => new BoxingGym(gymName),
                nameof(WeightliftingGym) => new WeightliftingGym(gymName),
                _ => throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType))
            };
            gyms.Add(gym);
            return String.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            var gym = gyms.FirstOrDefault(x => x.Name == gymName);
            double weight = gym.Equipment.Sum(x => x.Weight);

            return String.Format(OutputMessages.EquipmentTotalWeight, gymName, weight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            var desiredEquipment = equipment.FindByType(equipmentType);
            var gymToAdd = gyms.FirstOrDefault(x => x.Name == gymName);
            if (desiredEquipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gymToAdd.AddEquipment(desiredEquipment);
            equipment.Remove(desiredEquipment);

            return String.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);

        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            var gymToTrain = gyms.FirstOrDefault(x => x.Name == gymName);
            gymToTrain.Exercise();

            return String.Format(OutputMessages.AthleteExercise, gymToTrain.Athletes.Count);
        }
    }
}
