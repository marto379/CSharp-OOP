using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;

        public RaceRepository()
        {
            races = new List<IRace>();
        }
        public IReadOnlyCollection<IRace> Models => races;

        public void Add(IRace model)
        {
            races.Add(model);
        }

        public IRace FindByName(string name)
        {
            var race = races.FirstOrDefault(r => r.RaceName == name);
            return race;
        }

        public bool Remove(IRace model) => races.Remove(model);
        
    }
}
