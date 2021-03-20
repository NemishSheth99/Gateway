using AutoMapper;
using HAA.API.Models;
using HAA.BAL.Helper;
using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HAA.API.Helper
{
    public class AutomapperProfileApiDl:Profile
    {
        public AutomapperProfileApiDl()
        {
            CreateMap<HotelModel, Hotel>().ReverseMap();

            CreateMap<RoomModel, Room>().ReverseMap();

            CreateMap<BookingModel, Booking>().ReverseMap();

        }
    }
}