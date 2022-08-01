

namespace PersonInfo
{
    
    public class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public int age;
        public string name;

        public Citizen(string name, int age,string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }
        public int Age
        {
            get => this.age;
            set => this.age = value;

        }
        public string Name { get => this.name; set => this.name = value; }

        public string Id  { get; private set; }

        public string Birthdate { get; private set; }
    }
}