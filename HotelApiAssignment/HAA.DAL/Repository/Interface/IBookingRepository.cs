using HAA.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.DAL.Repository.Interface
{
    public interface IBookingRepository
    {
        bool RoomAvailable(int roomId, DateTime date);
        int CreateBooking(tblBookingStatu booking);
        bool DeleteBooking(int bookingId);
        bool EditBooking(tblBookingStatu booking);
    }
}
