using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.BAL.Interface
{
    public interface IRoomManager
    {
        IEnumerable<Room> GetRooms(string city, string pincode, decimal? price, byte? category); 
        bool CreateRooms(IEnumerable<Room> rooms);
        int CreateRoom(Room room);

    }
}