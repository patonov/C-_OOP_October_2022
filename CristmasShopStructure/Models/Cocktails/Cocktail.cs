using ChristmasPastryShop.Models.Cocktails.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string cocktailName;
        private string size;
        private double price;

        public Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }


        public string Name 
        { 
            get => this.cocktailName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.cocktailName = value;
            }
        }

        public string Size 
        { 
            get => this.size; 
            private set => this.size = value; 
        }

        public double Price 
        {
            get => this.price;
            private set
            {
                if (this.Size == "Large")
                {
                    this.price = value;
                }
                if (this.Size == "Middle")
                {
                    this.price = value * 0.67;
                }
                if (this.Size == "Small")
                {
                    this.price = value * 0.33;
                }
            }                
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.Size}) - {(this.Price):F2} lv";
        }
    }
}
