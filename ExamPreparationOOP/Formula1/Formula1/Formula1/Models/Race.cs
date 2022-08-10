using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        
        private string raceName;
        private int numberOfLaps;
        

        public Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numberOfLaps = numberOfLaps;
            this.TookPlace = false;
            this.Pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get
            {
                return raceName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid race name: {raceName}.");
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set
            {
                if (value < 1)
                    throw new ArgumentException($"Invalid lap numbers: {numberOfLaps}.");
                numberOfLaps = value;
            }
        }



        public ICollection<IPilot> Pilots {get;private set;}

        public bool TookPlace { get; set; }

        public void AddPilot(IPilot pilot)
        {
            Pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {Pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            sb.Append($"Took place: {(this.TookPlace ? "Yes" : "No")}");

            return sb.ToString();
        }
    }
}
