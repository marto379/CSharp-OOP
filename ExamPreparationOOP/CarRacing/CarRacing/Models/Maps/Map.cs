using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                var winner = racerTwo;
                return String.Format(OutputMessages.RaceCannotBeCompleted);
            }
            else if (!racerTwo.IsAvailable())
            {
                var winner = racerOne;
                return String.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, racerTwo.Username);
            }
            else if (!racerOne.IsAvailable())
            {
                var winner = racerTwo;
                return String.Format(OutputMessages.OneRacerIsNotAvailable, winner.Username, racerOne.Username);
            }
            racerOne.Race();
            racerTwo.Race();

            var behaviorMultiplierRacerOne = 1.0;
            if (racerOne.RacingBehavior == "strict")
            {
                behaviorMultiplierRacerOne = 1.2;
            }
            else
            {
                behaviorMultiplierRacerOne = 1.1;
            }

            var behaviorMultiplierRacerTwo = 1.0;

            if (racerTwo.RacingBehavior == "strict")
            {
                behaviorMultiplierRacerTwo = 1.2;
            }
            else
            {
                behaviorMultiplierRacerTwo = 1.1;
            }

            var chanceOfWinningOne = racerOne.Car.HorsePower * racerOne.DrivingExperience * behaviorMultiplierRacerOne;
            var chanceOfWinningTwo = racerTwo.Car.HorsePower * racerTwo.DrivingExperience * behaviorMultiplierRacerTwo;

            if (chanceOfWinningOne > chanceOfWinningTwo)
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerOne.Username);
            }
            else
            {
                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, racerTwo.Username);
            }
        }
    }
}
