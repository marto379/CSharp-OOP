using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0m;
        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = type switch
            {
                nameof(Water) => new Water(name, portion, brand),
                nameof(Tea) => new Tea(name, portion, brand)
            };
            drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = type switch
            {
                nameof(Bread) => new Bread(name, price),
                nameof(Cake) => new Cake(name, price),

            };
            bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, name, type);

        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = type switch
            {
                nameof(OutsideTable) => new OutsideTable(tableNumber, capacity),
                nameof(InsideTable) => new InsideTable(tableNumber, capacity)

            };

            tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var sb = new StringBuilder();
            var freeTables = tables.Where(t => !t.IsReserved);
            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            var bill = table.GetBill();
            totalIncome += bill;
            table.Clear();

            return $"Table: {tableNumber} \n Bill: {bill}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            var drink = drinks.FirstOrDefault(f => f.Name == drinkName && f.Brand == drinkBrand);
            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            return String.Format($"Table {tableNumber} ordered {drinkName} {drinkBrand}");
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            var food = bakedFoods.FirstOrDefault(f => f.Name == foodName);
            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            var freeTables = tables.Where(t => !t.IsReserved && t.Capacity >= numberOfPeople).ToList();
            if (freeTables.Count() == 0)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                var table = freeTables.First();
                table.Reserve(numberOfPeople);

                return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
