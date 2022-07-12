

namespace Animals
{
    public class Kitten : Cat
    {
        private const string DefGen = "Female";
        public Kitten(string name, int age) 
            : base(name, age, DefGen)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
