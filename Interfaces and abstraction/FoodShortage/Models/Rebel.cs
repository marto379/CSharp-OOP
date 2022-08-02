
namespace FoodShortage.Models
{
using FoodShortage.Models.Interfaces;
    public class Rebel : IBuyer
    {
        private string name;
        private int age;
        private string group;
        private int food;
        public Rebel(string name, int age, string group)
        {
            Name = name;
            Age = age;
            Group = group;
            Food = food;
           
        }

        

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }


        public int Age {get;private set;}

        public int Food { get;private set; } = 0;

        public string Group { get; set; }


        public void BuyFood()
        {
            Food += 5;
        }
    }
}
