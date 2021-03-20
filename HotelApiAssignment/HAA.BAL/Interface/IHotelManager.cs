using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.BAL.Interface
{
    public interface IHotelManager
    {
        IEnumerable<Hotel> GetHotels();
        int CreateHotel(Hotel hotel);
    }
}
