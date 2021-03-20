using HAA.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.DAL.Repository.Interface
{
    public interface IRoomRepository
    {
        IEnumerable<tblRoom> GetRooms(string city, string pincode, decimal? price, byte? category);
        bool CreateRooms(IEnumerable<tblRoom> rooms);
        int CreateRoom(tblRoom room);
    }
}
