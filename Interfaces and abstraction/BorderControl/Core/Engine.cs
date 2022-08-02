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
            List<IIdentifaible> allParticipans = new List<IIdentifaible>();
            string command;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (input.Length == 2)
                {
                    IIdentifaible robot = new Robot(input[1], input[0]);
                    allParticipans.Add(robot);
                }
                else
                {
                    IIdentifaible citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    allParticipans.Add(citizen);
                }
            }

            string fakeDigits = Console.ReadLine();
            List<IIdentifaible> sorted = allParticipans.Where(p => p.Id.EndsWith(fakeDigits)).ToList();

            PrintDetained(sorted);

        }
        private void PrintDetained(List<IIdentifaible> detained)
        {
            foreach (var item in detained)
            {
                Console.WriteLine(item.Id);
            }
        }
            
                
                   
    }
}
    

