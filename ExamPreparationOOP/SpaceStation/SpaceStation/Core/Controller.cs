using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private int exploredPlanest = 0;

        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            
            
            Astronaut astronaut = type switch
            {
                nameof(Biologist) => new Biologist(astronautName),
                nameof(Meteorologist) => new Meteorologist(astronautName),
                nameof(Geodesist) => new Geodesist(astronautName),
                _ => throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType)
            };
            astronauts.Add(astronaut);
            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded,planetName);
            
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronautsToSend = astronauts.Models.Where(a => a.Oxygen > 60).ToList();
            if (!astronautsToSend.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }
            var planetToExplore = planets.FindByName(planetName);

            Mission mission = new Mission();
            mission.Explore(planetToExplore, astronautsToSend);
            exploredPlanest++;

            int deahCount = astronautsToSend.Count(a => a.CanBreath == false);

            return String.Format(OutputMessages.PlanetExplored, planetName, deahCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{exploredPlanest} planets were explored!")
                .AppendLine("Astronauts info:");
            foreach (var astro in astronauts.Models)
            {
                sb.AppendLine($"Name: {astro.Name}")
                    .AppendLine($"Oxygen: {astro.Oxygen}")
                    .AppendLine($"Bag items: {(astro.Bag.Items.Any() ? string.Join(", ", astro.Bag.Items): "none")}");
            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astro = astronauts.FindByName(astronautName);
            if (astro == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronauts.Remove(astro);
            return string.Format(OutputMessages.AstronautRetired,astro.Name);
        }
    }
}
