using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId; 
        private int capacity;
        private double currentBill;
        private double turnover;
        private IRepository<IDelicacy> delicacyMenu;
        private IRepository<ICocktail> cocktailMenu;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
            this.IsReserved = false;
        }

        public int BoothId 
        {
            get => this.boothId;
            private set 
            {
                this.boothId = value;
            }
        }

        public int Capacity
        { 
        get => this.capacity;
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Capacity has to be greater than 0!");
                }
                this.capacity = value;
            }
        }

        public IRepository<IDelicacy> DelicacyMenu => this.delicacyMenu;

        public IRepository<ICocktail> CocktailMenu => throw new NotImplementedException();

        public double CurrentBill
        {
            get => this.currentBill;
            private set
            {
                this.currentBill = value;
            }
        }

        public double Turnover
        {
            get => this.turnover;
            
        }

        public bool IsReserved
        {
            get; set;
        }

        public void ChangeStatus()
        {
            if (this.IsReserved == false)
            {
                this.IsReserved = true;
            }
            else
            {
                this.IsReserved = false;
            }
        }

        public void Charge()
        {
            this.turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {(this.Turnover):F2} lv");

            sb.AppendLine("-Cocktail menu:");
            foreach (var coci in this.cocktailMenu.Models)
            {
                sb.AppendLine($"--{coci.ToString()}");
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (var deli in this.delicacyMenu.Models)
            {
                sb.AppendLine($"--{deli.ToString()}");
            }

            return sb.ToString().Trim();
        }
    }
}
