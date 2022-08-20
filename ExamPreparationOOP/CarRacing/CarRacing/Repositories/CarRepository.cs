using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private  ICollection<ICar> models;
        public CarRepository()
        {
            models = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => (IReadOnlyCollection<ICar>)models;

        public void Add(ICar model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(model);

        }

        public ICar FindBy(string property)
        {
            var car = Models.FirstOrDefault(c => c.VIN == property);
            return car;
        }

        public bool Remove(ICar model) => models.Remove(model);
        
    }
}
