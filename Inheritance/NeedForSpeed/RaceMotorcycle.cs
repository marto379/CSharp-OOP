

namespace NeedForSpeed
{
    public class RaceMotorcycle : Motorcycle
    {
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.DefFuelConsumption = 8;
        }

        public override double FuelConsumption => this.DefFuelConsumption;
    }
}
