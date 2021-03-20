using AutoMapper;
using HAA.DAL.Database;
using HAA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.BAL.Helper
{
    public class AotomapperProfileBDL:Profile
    {
        public AotomapperProfileBDL()
        {
            CreateMap<Hotel, tblHotel>().ReverseMap();

            CreateMap<Room, tblRoom>().ForMember(d=>d.RoomCategory,act=>act.MapFrom(s=>(byte)s.RoomCategory));
            CreateMap<tblRoom, Room>().ForMember(d => d.RoomCategory, act => act.MapFrom(s => (RoomCategoryEnum)s.RoomCategory));

            CreateMap<Booking, tblBookingStatu>().ForMember(d => d.BookingStatus, act => act.MapFrom(s => (byte)s.BookingStatus));
            CreateMap<tblBookingStatu, Booking>().ForMember(d => d.BookingStatus, act => act.MapFrom(s => (BookingStatusEnum)s.BookingStatus));
        }
    }
}
