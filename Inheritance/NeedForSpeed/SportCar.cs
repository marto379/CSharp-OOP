

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.DefFuelConsumption = 10;
        }

        public override double FuelConsumption => this.DefFuelConsumption;
    }
}
