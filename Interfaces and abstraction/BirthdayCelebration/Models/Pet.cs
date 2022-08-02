using BorderControl.Models.Interfaces;


namespace BorderControl.Models
{
    public class Pet : IBirthable
    {
        string name;
        string birthdate;

        public Pet(string name,string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
       
        public string Name { get;private set; }
        public string Birthdate {get;private set;}
    }

}
