using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private ICollection<IEquipment> equipments;
        private ICollection<IAthlete> athletes;

        public Gym(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Equipment = new HashSet<IEquipment>();
            this.Athletes = new HashSet<IAthlete>();    
        }

        public string Name
        {
            get { return name; }
            protected set {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);
                }
                name = value; }
        }

        public int Capacity
        {
            get { return capacity; }
            protected set
            {
                this.capacity = value;
            }
        }

        public double EquipmentWeight => Equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment { get; }

        public ICollection<IAthlete> Athletes  {get;}

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count + 1 > capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);
            }
            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlet in Athletes)
            {
                athlet.Exercise();
            }
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            var athletesListInfo = Athletes.Any() ? String.Join(", ", Athletes.Select(x => x.FullName)) : "No athletes";

            sb.AppendLine($"{this.Name} is a {GetType().Name}:")
                .AppendLine($"Athletes: {athletesListInfo}")
                .AppendLine($"Equipment total count: {Equipment.Count}")
                .AppendLine($"Equipment total weight: {this.EquipmentWeight:f2} grams");

            return sb.ToString().TrimEnd();
        }

        public bool RemoveAthlete(IAthlete athlete) => Athletes.Remove(athlete);
        
    }
}
