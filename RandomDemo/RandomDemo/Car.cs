﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RandomDemo
{
    public class Car : IComparable<Car>
    {
        private string make;
        private string model;
        private int year;

        private double fuelQuantity;
        private double fuelConsumption;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2024;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year) : this()
        { 
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this(make, model, year)
        { 
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public string Make 
        {
            get
            {
                return this.make;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The value you are submitting cannot be null or white space!");
                }
                this.make = value;
            }
        }

        public string Model 
        {
            get => this.model;
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The value you are submitting cannot be null or white space!");
                }
                this.model = value;
            }
        }

        public int Year 
        {
            get => this.year;
            set
            {
                if (value <= 0 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("The year of production of a car could not be higher than our current year");
                }
                this.year = value;
            }
        }

        public double FuelQuantity 
        { 
            get => this.fuelQuantity;
            set
            { 
            this.fuelQuantity = value;
            }
        }

        public double FuelConsumption
        { 
            get => this.fuelConsumption;
            set
            { 
                this.fuelConsumption = value;
            }
        }

        public int CompareTo(Car other)
        {
            int result = this.Make.CompareTo(other.Make);

            if (result == 0)
            { 
                result = this.Year.CompareTo(other.Year);
            }
            return result;
        }

        public void Drive(double distance)
        {
            distance /= 100;

            if (this.FuelQuantity - distance * this.FuelConsumption > 0)
            {
                this.FuelQuantity -= (distance * this.FuelConsumption);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string WhoAmI()
        {
            return $"Make: {this.Make}\nModel: {this.Model}\nYear: {this.Year}\nFuel: {this.FuelQuantity:F2}L";
        }

    }
}
