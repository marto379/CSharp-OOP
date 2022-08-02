
namespace BorderControl.Models
{
    using BorderControl.Models.Interfaces;

    public class Robot : IIdentifaible
    {
        string id;
        string model;

        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
            
        }

        public string Model{get;private set;}
        public string Id { get; private set; }
    }
}
