
namespace PersonInfo
{
    public class Citizen : IPerson
    {
        public int age;
        public string name;

        public Citizen(string name,int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public int Age
        {
            get => this.age;
            set => this.age = value;

        }
        public string Name { get => this.name; set => this.name = value; }
    }
}