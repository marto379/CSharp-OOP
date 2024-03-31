namespace Abstraction_And_Iterfaces
{
    
    public class Croco : Animal
    {
        public Croco() : base(FoodType.Meat,20)
        {

        }
        
        public void ScarePeople()
        {
            Console.WriteLine("Pa");
        }
    }
}
