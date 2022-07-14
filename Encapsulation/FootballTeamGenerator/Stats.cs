using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stats
    {
        private const int minValue = 0;
        private const int maxValue = 100;

        int endurance;
        int sprint;
        int dribble;
        int passing;
        int shooting;

        public Stats(int endurande, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurande;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
            
        }

        public int Endurance
        {
            get
            {
                return endurance;
            }
            private set
            {
                if (value < minValue || value > maxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatsRangeExeption, nameof(this.Endurance)));
                }
                endurance = value;
            }
        }


        public int Sprint
        {
            get { return sprint; }
            private set
            {
                if (value < minValue || value > maxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatsRangeExeption, nameof(this.Sprint)));
                }
                sprint = value;
            }
        }



        public int Dribble
        {
            get { return dribble; }
            private set
            {
                if (value < minValue || value > maxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatsRangeExeption, nameof(this.Dribble)));
                }
                dribble = value;
            }
        }



        public int Passing
        {
            get { return passing; }
            private set
            {
                if (value < minValue || value > maxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatsRangeExeption, nameof(this.Passing)));
                }
                passing = value;
            }
        }


        public int Shooting
        {
            get { return shooting; }
            private set
            {
                if (value < minValue || value > maxValue)
                {
                    throw new ArgumentException(String.Format(ErrorMessages.StatsRangeExeption, nameof(this.Shooting)));
                }
                shooting = value;
            }
        }
        public int GetAverageStats()
            => (int)Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);

    }
}
