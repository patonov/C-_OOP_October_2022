﻿using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;
        private string vin;
        private int horsePower;
        private double fuelAvailable;
        private double fuelConsumptionPerRace;

        public Car(string make, string model, string VIN, int horsePower, double fuelAvailable, double fuelConsumptionPerRace)
        {
            this.Make = make;
            this.Model = model;
            this.VIN = VIN;
            this.HorsePower = horsePower;
            this.FuelAvailable = fuelAvailable;
            this.FuelConsumptionPerRace = fuelConsumptionPerRace;
        }


        public string Make
        {
            get => this.make;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car make cannot be null or empty.");
                }
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car model cannot be null or empty.");
                }
                this.model = value;
            }
        }

        public string VIN
        {
            get => this.vin;
            private set 
            {
                if (value.Length != 17)
                {
                    throw new ArgumentException("Car VIN must be exactly 17 characters long.");
                }
                this.vin = value;
            }
        }

        public virtual int HorsePower
        {
            get => this.horsePower;
            protected set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Horse power cannot be below 0.");
                }
                this.horsePower = value;
            }
        }

        public double FuelAvailable
        {
            get
            {                
                return this.fuelAvailable;             
            }
            private set 
            {
                this.fuelAvailable = value;
                if (this.fuelAvailable < 0)
                {
                    this.fuelAvailable = 0;
                }                
            }
        
        }

        public double FuelConsumptionPerRace
        {
            get => this.fuelConsumptionPerRace;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Fuel consumption cannot be below 0.");
                }
                this.fuelConsumptionPerRace = value;
            }
        }

        public void Drive()
        {
            this.FuelAvailable -= FuelConsumptionPerRace;
        }
    }
}
