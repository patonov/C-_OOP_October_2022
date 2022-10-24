using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room { get; set; }
        
        public int ResidenceDuration 
        { 
            get => this.residenceDuration;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                else
                {
                    this.residenceDuration = value;
                }
            }
        }

        public int AdultsCount 
        { 
            get => this.adultsCount;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                else
                {
                    this.adultsCount = value;
                }
            }
        }

        public int ChildrenCount 
        {
            get => this.childrenCount;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                else
                {
                    this.childrenCount = value;
                }
            }
        }

        public int BookingNumber => this.bookingNumber;
            
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {this.Room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Total amount paid: {TotalPaid():f2} $");

            return sb.ToString().Trim();
        }

        private double TotalPaid() => Math.Round(this.Room.PricePerNight * this.residenceDuration, 2);
    }
}
