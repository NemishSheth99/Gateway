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
    public class BookingRepository : IBookingRepository
    {
        private readonly WebApiAssEntities _context;

        public BookingRepository()
        {
            _context = new WebApiAssEntities();
        }
        public int CreateBooking(tblBookingStatu booking)
        {
            _context.tblBookingStatus.Add(booking);
            if (_context.SaveChanges() == 1)
            {
                return booking.Id;
            }
            else
            {
                return 0;
            }
        }

        public bool DeleteBooking(int bookingId)
        {
            var bookingInDb = _context.tblBookingStatus.Where(b => b.Id == bookingId).FirstOrDefault();
            if (bookingInDb != null)
            {
                bookingInDb.BookingStatus = (byte)BookingStatusEnum.Deleted;
                if (_context.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RoomAvailable(int roomId, DateTime date)
        {
            if (_context.tblBookingStatus
               .Where(b => b.RoomId == roomId && b.BookingDate == date && b.BookingStatus < (byte)BookingStatusEnum.Cancelled)
              .FirstOrDefault() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditBooking(tblBookingStatu booking)
        {
            _context.tblBookingStatus.Attach(booking);
            _context.Entry(booking).State = System.Data.Entity.EntityState.Modified;
            if (_context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
