﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuel;

        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity, double airConditionModifier)
        {
            this.TankCapacity = tankCapacity;
            this.Fuel = fuel;
            this.FuelConsumption = fuelConsumption;
            this.AirConditionModifier = airConditionModifier;
        }

        protected double AirConditionModifier { get; set; }

        public double Fuel
        {
            get => this.fuel;

            protected set
            {
                if (value > this.TankCapacity)
                {
                    this.fuel = 0;
                }
                else
                {
                    this.fuel = value;
                }
            }
        }

        public double FuelConsumption { get; private set; }

        public double TankCapacity { get; private set; }


        public void Drive(double distance)
        {
            double fuelNeeded = (this.FuelConsumption + this.AirConditionModifier) * distance;

            if (fuelNeeded > this.Fuel)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            this.Fuel -= fuelNeeded;
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (this.Fuel + amount > this.TankCapacity)
            {
                throw new InvalidOperationException($"Cannot fit {amount} fuel in the tank");
            }

            this.Fuel += amount;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.Fuel:f2}";
        }
    }
}
