using BorderControl.Models.Interfaces;
using System.Collections.Generic;

namespace BorderControl.Models
{
    public class Detained : IIdentifaible
    {
        List<IIdentifaible> detained;

        public Detained()
        {
            detained = new List<IIdentifaible>();
        }
        public string Id { get; }
    }
    
}
