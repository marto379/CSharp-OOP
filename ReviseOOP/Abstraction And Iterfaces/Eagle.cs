namespace Abstraction_And_Iterfaces
{
   
    public class Eagle : Animal
    {
        public Eagle():base(FoodType.Oats,10)
        {
            
        }
        public void Fly()
        {
            Console.WriteLine("I am flying");
        }
    }
}
