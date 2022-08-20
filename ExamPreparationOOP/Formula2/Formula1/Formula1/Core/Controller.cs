using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepo;
        private FormulaOneCarRepository carsRepo;
        private RaceRepository racesRepo;

        public Controller()
        {
            pilotRepo = new PilotRepository();
            carsRepo = new FormulaOneCarRepository();
            racesRepo = new RaceRepository();
        }
        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = pilotRepo.FindByName(pilotName);
            if (pilot == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotName));
            }
            var car = carsRepo.FindByName(carModel);
            if (car == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            carsRepo.Remove(car);

            return String.Format(OutputMessages.SuccessfullyPilotToCar,pilotName,car.GetType().Name,carModel);
        }
        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = racesRepo.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var pilot = pilotRepo.FindByName(pilotFullName);
            if (pilot == null  || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);

            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidF1CarModel, type)),
            };

            if (carsRepo.FindByName(model) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }

            carsRepo.Add(car);
            return String.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            if (pilotRepo.FindByName(fullName) != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            var pilot = new Pilot(fullName);
            pilotRepo.Add(pilot);
            return String.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            if (racesRepo.FindByName(raceName) != null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            var race = new Race(raceName, numberOfLaps);
            racesRepo.Add(race);
            return String.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var sb = new StringBuilder();

            foreach (var pilot in pilotRepo.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine($"Pilot {pilot.FullName} has {pilot.NumberOfWins} wins.");
            }
            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            var sb = new StringBuilder();

            foreach (var race in racesRepo.Models.Where(r => r.TookPlace))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            var race = racesRepo.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(String.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if (race.TookPlace == true)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
           var racers = race.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            var winner = racers[0];
            var second = racers[1];
            var third = racers[2];

            winner.WinRace();
            race.TookPlace = true;

            var sb = new StringBuilder();

            sb.AppendLine($"Pilot {winner.FullName} wins the {raceName} race.")
                .AppendLine($"Pilot {second.FullName} is second in the {raceName} race.")
                .AppendLine($"Pilot {third.FullName} is third in the {raceName} race.");

            return sb.ToString().TrimEnd();
        }
    }
}
