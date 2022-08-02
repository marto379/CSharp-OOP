namespace BorderControl.Models
{
using BorderControl.Models.Interfaces;
    public class Citizen :IIdentifaible,IBirthable
    {
        string name;
        int age;
        string id;

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }

        public string Id {get;private set;}
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Birthdate {get; private set;}
    }
}
