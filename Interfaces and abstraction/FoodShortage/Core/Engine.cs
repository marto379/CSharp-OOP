
namespace FoodShortage.Core
{
using Core;
    using FoodShortage.Models;
    using FoodShortage.Models.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine : IEngine
    {
        public void Start()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int food = 0;

            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 3)
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string group = input[2];

                    IBuyer rebel = new Rebel(name, age, group);
                    buyers.Add(rebel);
                }
                else
                {
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    string id = input[2];
                    string birthdate = input[3];

                    buyers.Add(new Citizen(name, age, id));
                }
            }

            string names;
            while ((names = Console.ReadLine()) != "End")
            {
                if (buyers.Any(b => b.Name == names))
                {
                    var buyer = buyers.First(b => b.Name == names);
                    buyer.BuyFood();
                }
            }

            foreach (var buyer in buyers)
            {
                food += buyer.Food;
            }
            Console.WriteLine(food);

        }
    }
}
