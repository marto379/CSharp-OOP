using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int comfortOrnament = 1;
        private const decimal priceOrnament = 5m;

        public Ornament() 
            : base(comfortOrnament, priceOrnament)
        {
        }
    }
}
