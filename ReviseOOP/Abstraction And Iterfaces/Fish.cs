namespace Abstraction_And_Iterfaces
{
   
    public class Fish : Animal
    {
        public Fish(): base(FoodType.Wheat,2)
        {
            
        }
        public void Swim()
        {
            Console.WriteLine("I am swimming");
        }
    }
}
