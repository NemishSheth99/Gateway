using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.BAL.Interface
{
    public interface IBookingManager
    {
        bool RoomAvailable(int roomId, DateTime date);
        int CreateBooking(Booking booking);
        bool DeleteBooking(int bookingId);
        bool UpdateBooking(Booking booking);
    }
}
