using Formula1.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
       private string fullName;
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.CanRace = false;
            this.NumberOfWins = 0;
        }

        public string FullName
        { 
            get
            { 
                return fullName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Invalid pilot name: {fullName}.");
                }
                fullName = value;
            }
        }
        

        public IFormulaOneCar Car
        {
            get
            {
                return car;
            }
            private set
            {
                if (value == null)
                {
                    throw new NullReferenceException($"Pilot car can not be null.");
                }
                car = value;
            }
        }

        public int NumberOfWins { get;private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            Car = car;
            CanRace = true;
        }

        public void WinRace()
        {
            NumberOfWins++;
        }

        public override string ToString()
        {
            return $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
        }
    }
}
