namespace Abstraction_And_Iterfaces
{
    using Abstraction_And_Iterfaces.Contracts;

    internal class Program
    {
        static void Main(string[] args)
        {
            CareTaker careTaker = new CareTaker();
            careTaker.Feed(new Eagle());
            careTaker.Feed(new Croco());
            careTaker.Feed(new Fish());
            careTaker.Feed(new Baby());

            Croco croco = new Croco();
            croco.Eat();

            IFeedable feedable = new Lion();
            feedable.Eat();
        }
    }
}