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
    public class HotelRepository : IHotelRepository
    {
        private readonly WebApiAssEntities _context;

        public HotelRepository()
        {
            _context = new WebApiAssEntities();
        }

        public int CreateHotel(tblHotel hotel)
        {
            _context.tblHotels.Add(hotel);
            if (_context.SaveChanges() == 1)
            {
                return hotel.Id;
            }
            else
                return 0;
            throw new NotImplementedException();
        }

        public IEnumerable<tblHotel> GetHotels()
        {
            return _context.tblHotels.OrderBy(h => h.City).ThenBy(h => h.Name).ToList();
        }
    }
}
