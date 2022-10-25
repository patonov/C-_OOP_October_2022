using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HotelCtor_SetsNameAndCategoryCorrectly()
        {
            var hotel = new Hotel("Kavaler", 3);

            string expectedName = "Kavaler";
            int expectedCategory = 3;
            var expectedTurnover = 0;

            Assert.That(hotel.FullName, Is.EqualTo(expectedName));
            Assert.That(hotel.Category, Is.EqualTo(expectedCategory));
            Assert.That(hotel.Turnover, Is.EqualTo(expectedTurnover));
        }

        [Test]
        public void HotelCtor_ThrowsException_WhenInvalidNameAndCategory()
        {            
            Assert.Throws<ArgumentNullException>(() => new Hotel(" ", 5));
            Assert.Throws<ArgumentException>(() => new Hotel("NewHotel", 6));
            Assert.Throws<ArgumentException>(() => new Hotel("NewHotel", 0));
        }

        [Test]
        public void AddRoom_AddsRoomsCorrectly()
        {
            var hotel = new Hotel("HotelName", 5);
            var room = new Room(3, 57);

            hotel.AddRoom(room);

            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
        }

        [Test]
        public void BookRoom_ThrowsExceptionWhenAdultsAreIncorect()
        {
            Hotel hotel = new Hotel("California", 4);
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(0, 1, 7, 700));
        }

        [Test]
        public void BookRoom_ThrowsExceptionWhenChildrenAreLessThanZero()
        {
            Hotel hotel = new Hotel("California", 4);
            Room room = new Room(3, 100);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(3, -1, 7, 700));
        }

        [Test]
        public void BookRoom_ThrowsExceptionWhenResidenceIsLessThanOne()
        {
            Hotel hotel = new Hotel("California", 4);
            Room room = new Room(4, 100);
            hotel.AddRoom(room);

            Assert.Throws<ArgumentException>(() => hotel.BookRoom(2, 1, 0, 700));
        }

        [Test]
        public void BookRoom_NoBookingAllowedWhenInsufficientNumberOfBeds()
        {
            Hotel hotel = new Hotel("California", 4);
            Room room = new Room(4, 100);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 3, 2, 700);

            Assert.That(hotel.Turnover, Is.EqualTo(0));               
        }

        [Test]
        public void BookRoom_NoBookingAllowedWhenInsufficientBudget()
        {
            Hotel hotel = new Hotel("California", 4);
            Room room = new Room(4, 100);
            hotel.AddRoom(room);

            hotel.BookRoom(2, 3, 7, 100);

            Assert.That(hotel.Turnover, Is.EqualTo(0));
            Assert.That(hotel.Bookings.Count.Equals(0));
            Assert.That(hotel.Rooms.Count.Equals(1));
        }

        [Test]
        public void BookRoom_TheMethodWorksCorrectly()
        {
            Hotel hotel = new Hotel("California", 4);
            Room room = new Room(2, 100);
            hotel.AddRoom(room);

            hotel.BookRoom(1, 1, 2, 900);
                        
            Assert.That(hotel.Bookings.Count.Equals(1));
            Assert.That(hotel.Rooms.Count.Equals(1));
        }









    }
}