using BookingApp.Repositories.Contracts;
using BookingApp.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms;

        public RoomRepository()
        {
            this.rooms = new List<IRoom>();
        }

        public void AddNew(IRoom model)
        {
            this.rooms.Add(model);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return this.rooms;
        }

        public IRoom Select(string roomTypeName)
        {
            return this.rooms.Find(x => x.GetType().Name == roomTypeName);
        }
    }
}
