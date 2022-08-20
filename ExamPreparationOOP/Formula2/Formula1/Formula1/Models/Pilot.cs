using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private bool canRace;
        private IFormulaOneCar car;
        private int numberOfWins;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
            canRace = false;
            numberOfWins = 0;
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot,value));
                }
                fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get { return car; }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);
                }
                car = value;
            }
        }

        public int NumberOfWins => numberOfWins;

        public bool CanRace => canRace;

        public void AddCar(IFormulaOneCar car)
        {
           Car = car;
           canRace = true;
        }

        public void WinRace()
        {
            numberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {FullName} has {NumberOfWins} wins.";
        }
    }
}
