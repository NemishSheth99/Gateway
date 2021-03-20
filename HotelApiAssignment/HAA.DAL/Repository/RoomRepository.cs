using HAA.DAL.Database;
using HAA.DAL.Repository.Interface;
using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {  
        private readonly WebApiAssEntities _context;

        public RoomRepository()
        {
            _context = new WebApiAssEntities();
        }

        public int CreateRoom(tblRoom room)
        {
            _context.tblRooms.Add(room);
            if (_context.SaveChanges() > 0)
                return room.Id;
            else
                return 0;
        }
         

        public bool CreateRooms(IEnumerable<tblRoom> rooms)
        {
            _context.tblRooms.AddRange(rooms);
            if (_context.SaveChanges() == rooms.Count())
                return true;
            else
                return false;
        }


        public IEnumerable<tblRoom> GetRooms(string city, string pincode, decimal? price, byte? category)
        {
            IEnumerable<tblRoom> roomsList = _context.tblRooms.AsQueryable();

            if (city != null)
            {
                roomsList = roomsList.Where(r => r.tblHotel.City.Contains(city));
            }
            if (pincode != null)
            {
                roomsList = roomsList.Where(r => r.tblHotel.Pincode.Contains(pincode));
            }
            if (price != null)
            {
                roomsList = roomsList.Where(r => r.RoomPrice >= price).OrderBy(r => r.RoomPrice);
            }
            if (category != null)
            {
                roomsList = roomsList.Where(r => r.RoomCategory == category);
            }
            return roomsList.ToList();
        }
    }
}
