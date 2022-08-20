using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
   
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private ICollection<IEquipment> models;

        public EquipmentRepository()
        {
            this.models = new HashSet<IEquipment>();
        }
        public IReadOnlyCollection<IEquipment> Models => (IReadOnlyCollection<IEquipment>)models;

        public void Add(IEquipment model)
        {
           models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            var equipmentToFind = models.FirstOrDefault(x => x.GetType().Name == type);
            return equipmentToFind;
        }

        public bool Remove(IEquipment model) => models.Remove(model);
        
    }
}
