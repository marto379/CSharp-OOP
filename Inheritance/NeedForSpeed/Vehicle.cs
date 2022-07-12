

namespace NeedForSpeed
{
    public class Vehicle
    {
        int horsePower;
        double fuel;
        double defFuelConsumption;
        double fuelConsumption;

        public double DefFuelConsumption { get; set; } = 1.25;
        public virtual double FuelConsumption
        {
            get
            {
                return DefFuelConsumption;
            }
        }

        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
           
        }

        public int HorsePower { get; set; }

        public double Fuel { get; set; }

       public virtual void Drive(double kilometers)
        {
            this.Fuel -= DefFuelConsumption * kilometers;
        }
    }
}
