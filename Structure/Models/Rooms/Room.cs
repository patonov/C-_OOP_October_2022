using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Rooms
{
    public abstract class Room : IRoom
    {
        private int bedCapacity;

        private double pricePerNight = 0;

        protected Room(int bedCapacity)
        {
            this.bedCapacity = bedCapacity;
        }
        public int BedCapacity => this.bedCapacity;

        public double PricePerNight 
        { 
            get => this.pricePerNight;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be negative!");
                }
                else
                {
                    this.pricePerNight = value;
                }
            }
        }

        public void SetPrice(double price)
        {
                this.PricePerNight = price;
        }
    }
}
