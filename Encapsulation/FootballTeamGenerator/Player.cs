using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        string name;


        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.Stats = stats;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ErrorMessages.NullOrWhiteSpace);
                }
                name = value;
            }

        }

        public Stats Stats { get; private set; }
    }
}
