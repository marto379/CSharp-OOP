namespace Abstraction_And_Iterfaces
{
    using Abstraction_And_Iterfaces.Contracts;

    public class Baby : IFeedable
    {
        public int Doze { get; set; }
        public FoodType FoodType { get; set; }

        public void Eat()
        {
            Console.WriteLine("Mryn");
        }
    }
}
