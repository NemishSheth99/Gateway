using HAA.API.Models;
using HAA.BAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using HAA.Models;

namespace HAA.API.Controllers
{
    [RoutePrefix("api/booking")]
    public class BookingController : ApiController 
    {
        private readonly IBookingManager _bookingManager;

        public BookingController(IBookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        } 


        [HttpGet]
        public IHttpActionResult RoomAvailable(int roomId, DateTime date)
        {
            var Availability = _bookingManager.RoomAvailable(roomId, date) ? "Available" : "Already Booked";
            return Ok(Availability);
        }


        [HttpPost]
        public IHttpActionResult BookRoom(BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                var bookingObj = Mapper.Map<Booking>(booking);
                booking.Id = _bookingManager.CreateBooking(bookingObj);
                if (booking.Id > 0)
                {
                    return Created("", booking);
                }
                else if (booking.Id == -1)
                {
                    return BadRequest("Already Booked");
                }
            }
            return BadRequest(ModelState);
        }

        
        [HttpDelete]
        public IHttpActionResult DeleteBooking(int bookingId)
        {
            if (_bookingManager.DeleteBooking(bookingId))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IHttpActionResult UpdateBooking(BookingModel booking)
        {
            if (ModelState.IsValid)
            {
                var bookingObj = Mapper.Map<Booking>(booking);
                if (_bookingManager.UpdateBooking(bookingObj))
                {
                    return Ok(booking);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
