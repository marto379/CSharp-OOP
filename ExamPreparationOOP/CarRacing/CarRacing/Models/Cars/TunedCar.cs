using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vinNum, int horsePower) 
            : base(make, model, vinNum, horsePower, 65, 7.5)
        {
        }
        public override void Drive()
        {
            base.Drive();
           HorsePower = (int)(HorsePower * 0.97);
        }
    }
}
