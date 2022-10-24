using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        
        public Hotel(string fullName, int category)
        {
            this.FullName = fullName;
            this.Category = category;
            this.Rooms = new RoomRepository();
            this.Bookings = new BookingRepository();
        }

        public string FullName 
        {
            get => this.fullName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                else
                {
                    this.fullName = value;
                }
            }
        }

        public int Category 
        {
            get => this.category;
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                else
                {
                    this.category = value;
                }
            }
        }

        public double Turnover
            => Math.Round(Bookings.All().Sum(x => x.ResidenceDuration * x.Room.PricePerNight), 2);

        public IRepository<IRoom> Rooms { get; set; }
        public IRepository<IBooking> Bookings { get; set; }


    }
}
