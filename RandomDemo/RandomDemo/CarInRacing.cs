using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class CarInRacing
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumption;
        private int traveledDistance;

        public CarInRacing(string model, double fuelAmount, double fuelConsumption)
        { 
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
        }

        public string Model { get; private set; }

        public double FuelAmount { get; private set; }

        public double FuelConsumption { get; private set; }

        public int TradeledDistance { get; private set; }

        public bool Drive(int distance)
        {
            if ((distance * this.FuelConsumption) <= this.FuelAmount)
            { 
                this.FuelAmount -= (distance * this.FuelConsumption);
                this.TradeledDistance += distance;
                return true;
            }

            return false;
        }

        public override string ToString() 
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TradeledDistance}";
        }

    }
}
