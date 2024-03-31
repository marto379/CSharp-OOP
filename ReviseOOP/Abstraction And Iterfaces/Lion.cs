namespace Abstraction_And_Iterfaces
{
    using Abstraction_And_Iterfaces.Contracts;

    public class Lion : IFeedable
    {
        public int Doze { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public FoodType FoodType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Eat()
        {

        }
    }
}
