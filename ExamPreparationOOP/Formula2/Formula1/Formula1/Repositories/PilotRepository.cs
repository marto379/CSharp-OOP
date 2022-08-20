using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> pilots;

        public PilotRepository()
        {
            pilots = new List<IPilot>();
        }
        public IReadOnlyCollection<IPilot> Models => pilots;

        public void Add(IPilot model)
        {
            pilots.Add(model);
        }

        public IPilot FindByName(string name)
        {
            var pilot = pilots.FirstOrDefault(p => p.FullName == name);
            return pilot;
        }

        public bool Remove(IPilot model) => pilots.Remove(model);
        
    }
}
