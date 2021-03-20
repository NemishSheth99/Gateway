using HAA.BAL.Interface;
using HAA.DAL.Repository.Interface;
using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HAA.DAL.Database;

namespace HAA.BAL
{
    public class BookingManager : IBookingManager
    {
        private readonly IBookingRepository _bookingRepository;
          
        public BookingManager(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }


        public int CreateBooking(Booking booking)
        {
            if (RoomAvailable(booking.RoomId, booking.BookingDate))
            {
                var bookingObj = Mapper.Map<tblBookingStatu>(booking);
                return _bookingRepository.CreateBooking(bookingObj);
            }
            else
            {
                return -1;
            }
        }


        public bool DeleteBooking(int bookingId)
        {
            return _bookingRepository.DeleteBooking(bookingId);
        }


        public bool RoomAvailable(int roomId, DateTime date)
        {
            return _bookingRepository.RoomAvailable(roomId, date);
        }


        public bool UpdateBooking(Booking booking)
        {
            var bookingObj = Mapper.Map<tblBookingStatu>(booking);
            return _bookingRepository.EditBooking(bookingObj);
        }
    }
}
