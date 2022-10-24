using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;

        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return this.bookings;
        }

        public IBooking Select(string bookingNumberToString)
        {
            return this.bookings.Find(x => x.BookingNumber.ToString() == bookingNumberToString);
        }
    }
}
