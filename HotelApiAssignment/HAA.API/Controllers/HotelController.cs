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
using HAA.API.Helper;

namespace HAA.API.Controllers
{
  
    public class HotelController : ApiController
    {
        private readonly IHotelManager _hotelManager;

        public HotelController(IHotelManager hotelManager)
        {    
            _hotelManager = hotelManager;
        }


        [HttpGet]
        public IHttpActionResult GetAllHotels()
        {
            var hotels = Mapper.Map<IEnumerable<HotelModel>>(_hotelManager.GetHotels());
            return Ok(hotels);
        }

        [HttpPost]
        public IHttpActionResult CreateHotel(HotelModel hotel)
        {

            if (ModelState.IsValid)
            {
                var hotelObj = Mapper.Map<Hotel>(hotel);
                hotel.Id = _hotelManager.CreateHotel(hotelObj);
                if (hotel.Id > 0)
                {
                    return Created("  ", hotel);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
