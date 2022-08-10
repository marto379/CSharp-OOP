using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Plant : Decoration
    {
        private const int comfortPlant = 5;
        private const decimal pricePlant = 10m;
        public Plant() 
            : base(comfortPlant, pricePlant)
        {
        }
    }
}
