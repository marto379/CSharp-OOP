using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class FreshwaterFish : Fish
    {
        private int size = 3;
        public FreshwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            Size = size;
        }
        

        public override void Eat()
        {
            Size += 3;
        }
    }
}
