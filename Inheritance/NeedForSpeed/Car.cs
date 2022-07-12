

namespace NeedForSpeed
{
    public class Car : Vehicle
    {
        public Car(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.DefFuelConsumption = 3;
        }

        public override double FuelConsumption => this.DefFuelConsumption;
    }
}
