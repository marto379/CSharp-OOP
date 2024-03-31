namespace Abstraction_And_Iterfaces
{
    using Abstraction_And_Iterfaces.Contracts;

    public class CareTaker
    {
        public void Feed(IFeedable feedable)
        {
            Console.WriteLine($"Get {feedable.Doze} {feedable.FoodType} from invertory");
            Console.WriteLine($"Feeding {feedable.GetType().Name}");
            feedable.Eat();
        }
    }
}
