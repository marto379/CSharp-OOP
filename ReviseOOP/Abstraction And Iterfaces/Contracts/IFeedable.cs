namespace Abstraction_And_Iterfaces.Contracts
{

    public interface IFeedable
    {
        void Eat();

        int Doze { get; set; }
        FoodType FoodType { get; set; }
    }
}
