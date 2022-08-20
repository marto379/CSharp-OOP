using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vinNum, int horsePower) 
            : base(make, model, vinNum, horsePower, 80, 10)
        {
        }
    }
}
