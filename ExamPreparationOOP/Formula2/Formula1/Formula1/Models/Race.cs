﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private List<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            tookPlace = false;
            pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get { return numberOfLaps;}
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers,value));
                }
                numberOfLaps = value;
            }
        }

        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }

        public ICollection<IPilot> Pilots => pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var sb = new StringBuilder();
            var tookPlaceResult = tookPlace ? "Yes" : "No";
            sb.AppendLine($"The {RaceName} race has:")
                .AppendLine($"Participants: {pilots.Count}")
                .AppendLine($"Number of laps: {NumberOfLaps}")
                .AppendLine($"Took place: {tookPlaceResult}");

            return sb.ToString().TrimEnd();
        }
    }
}
