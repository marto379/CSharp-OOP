namespace BorderControl.Core
{
    using System;
    using BorderControl.Models.Interfaces;
    using System.Collections.Generic;
    using BorderControl.Models;
    using System.Linq;

    public class Engine : IEngine
    {
        public void Start()
        {
            List<IBirthable> allParticipans = new List<IBirthable>();
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "Robot")
                {
                    continue;
                }
                else if(input[0] == "Citizen")
                {
                    IBirthable citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                    allParticipans.Add(citizen);
                }
                else if (input[0] == "Pet")
                {
                    IBirthable pet = new Pet(input[1], input[2]);
                    allParticipans.Add(pet);
                }
            }

            string birthdate = Console.ReadLine();
            List<IBirthable> sorted = allParticipans.Where(p => p.Birthdate.EndsWith(birthdate)).ToList();

            PrintDetained(sorted);

        }
        private void PrintDetained(List<IBirthable> detained)
        {
            foreach (var item in detained)
            {
                Console.WriteLine(item.Birthdate);
            }
        }
            
                
                   
    }
}
    

