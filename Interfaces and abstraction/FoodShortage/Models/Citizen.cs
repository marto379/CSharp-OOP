using FoodShortage.Models.Interfaces;

namespace FoodShortage.Models
{

    public class Citizen :IBuyer
    {
        string name;
        int age;
        string id;

        public Citizen(string name, int age, string id)
        {
            Name = name;
            Age = age;
            Id = id;
            
        }

        public string Id {get;private set;}
        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
