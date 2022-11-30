using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
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
        private List<Table> tables;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<Table>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;

            if (type == nameof(Tea))
            {
                drink = new Tea(name, portion, brand);
            }
            else
            {
                drink = new Water(name, portion, brand);
            }
            this.drinks.Add(drink);
            return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood bakedFood;

            if (type == nameof(Bread))
            {
                bakedFood = new Bread(name, price);
            }
            else
            {
                bakedFood = new Cake(name, price);
            }
            this.bakedFoods.Add(bakedFood);
            return $"Added {bakedFood.Name} ({bakedFood.GetType().Name}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table;

            if (type == nameof(InsideTable))
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            this.tables.Add(table);
            return $"Added table number {table.TableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in this.tables.Where(x => x.IsReserved == false))
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            var income = this.tables.Sum(x => x.GetBill());
            return $"Total income: {(income):F2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            var targetTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var bill = targetTable.GetBill();
            targetTable.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {(bill):F2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var targetTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drinkToOrder = this.drinks.FirstOrDefault(x => x.Name == drinkName);
            if (targetTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (drinkToOrder == null)
            {
                return $"There is no {drinkName} {drinkBrand} available";
            }

            targetTable.OrderDrink(drinkToOrder);
            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var targetTable = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var foodToOrder = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);

            if (targetTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            if (foodToOrder == null)
            {
                return $"No {foodName} in the menu";
            }

            targetTable.OrderFood(foodToOrder);
            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            Table tableToReserve = this.tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (tableToReserve == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else
            {
                tableToReserve.IsReserved = true;
                return $"Table {tableToReserve.TableNumber} has been reserved for {numberOfPeople} people";
            }
        }
    }
}
