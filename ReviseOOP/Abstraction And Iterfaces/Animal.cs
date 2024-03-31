namespace Abstraction_And_Iterfaces
{
    using Abstraction_And_Iterfaces.Contracts;

    public class Animal : IFeedable
    {
        public Animal(FoodType foodType, int doze)
        {
            FoodType = foodType;
            Doze = doze;
        }
        public FoodType FoodType { get; set; }

        public int Doze { get; set; }

        public virtual void Eat()
        {
            Console.WriteLine("I am eating");
        }

        public void Sleep()
        {
            Console.WriteLine("I am sleeping");
        }

        public void Play()
        {
            Console.WriteLine("I am playing");
        }
    }
}
