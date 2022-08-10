using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {

        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository carRepository;


        public string AddCarToPilot(string pilotName, string carModel)
        {

            IPilot pilot = pilotRepository.FindByName(pilotName);
            IFormulaOneCar car = carRepository.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }
            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }
            pilot.AddCar(car);
            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IPilot pilot = pilotRepository.FindByName(pilotFullName);
            IRace race = raceRepository.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            
            if (pilot == null || !pilot.CanRace || race.Pilots.Any(p => p.FullName == pilotFullName))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }
            
            race.AddPilot(pilot);
            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            
            if (carRepository == null)
            {
                carRepository = new FormulaOneCarRepository();
            }
            if (carRepository.Models.Any(c => c.Model == model))
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            IFormulaOneCar car = type switch
            {
                nameof(Ferrari) => new Ferrari(model, horsepower, engineDisplacement),
                nameof(Williams) => new Williams(model, horsepower, engineDisplacement),
                _ => throw new InvalidOperationException($"Formula one car type {type} is not valid.")
            };

            
            carRepository.Add(car);
            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            var pilot = new Pilot(fullName);
            if (pilotRepository == null)
            {
                pilotRepository = new PilotRepository();
            }
            if (pilotRepository.Models.Any(p => p.FullName == fullName))
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }
            pilotRepository.Add(pilot);
            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
           var race = new Race(raceName, numberOfLaps);
            if (raceRepository == null)
            {
                raceRepository = new RaceRepository();
            }
            if (raceRepository.Models.Any(r => r.RaceName == race.RaceName))
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }
            raceRepository.Add(race);
            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {

            StringBuilder sb = new StringBuilder();
            foreach (IPilot pilot in pilotRepository.Models.OrderByDescending(p => p.NumberOfWins))
            {
                sb.AppendLine(pilot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IRace race in raceRepository.Models.Where(r => r.TookPlace == true))
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {

            var currRace = raceRepository.FindByName(raceName);
            if (currRace == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }
            if (currRace.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }
            if (currRace.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            currRace.TookPlace = true;
            var topPilots = currRace.Pilots.OrderByDescending(p => p.Car.RaceScoreCalculator(currRace.NumberOfLaps)).ToList();

            var winner = topPilots[0];
            var second = topPilots[1];
            var third = topPilots[2];
            winner.WinRace();

            StringBuilder sb = new StringBuilder();
            sb
                .AppendLine($"Pilot {winner.FullName} wins the {raceName} race.")
                .AppendLine($"Pilot {second.FullName} is second in the {raceName} race.")
                .Append($"Pilot {third.FullName} is third in the {raceName} race.");

            return sb.ToString();


        }
    }
}
