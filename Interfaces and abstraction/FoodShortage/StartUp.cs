
namespace FoodShortage
{
    using FoodShortage.Core;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Start();
        }
    }
}
