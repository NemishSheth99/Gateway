using HAA.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.DAL.Repository.Interface
{
    public interface IHotelRepository
    {
        IEnumerable<tblHotel> GetHotels();
        int CreateHotel(tblHotel hotel);
    }
}
