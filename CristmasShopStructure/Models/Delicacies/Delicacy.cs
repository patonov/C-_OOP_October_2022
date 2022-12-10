using ChristmasPastryShop.Models.Delicacies.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        private string delicacyName;
        private double price;

        public Delicacy(string delicacyName, double price)
        {
            this.Name = delicacyName;
            this.Price = price;
        }

        public string Name 
        {
            get => this.delicacyName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace!");
                }
                this.delicacyName = value;
            }
        }

        public double Price 
        { 
            get => this.price;
            private set
            {
                this.price = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name} - {(this.Price):F2} lv";
        }
    }
}
