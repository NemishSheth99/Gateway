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
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomManager _roomManager;

        public HotelManager(IHotelRepository hotelRepository, IRoomManager roomManager)
        {
            _hotelRepository = hotelRepository;
            _roomManager = roomManager;
        }
        public int CreateHotel(Hotel hotel)
        {
            hotel.CreatedDate = DateTime.Now.Date;
            hotel.UpdatedDate = DateTime.Now.Date;
            var hotelObj = Mapper.Map<tblHotel>(hotel);
            
            hotel.Id = _hotelRepository.CreateHotel(hotelObj);
            
            if(hotel.Id!=0 && hotel.Rooms != null)
            {
                foreach (Room room in hotel.Rooms)
                {
                    room.HotelId = hotel.Id;
                    room.CreatedDate = DateTime.Now.Date;
                }
                _roomManager.CreateRooms(hotel.Rooms);
            }

            return hotel.Id;
        }

        public IEnumerable<Hotel> GetHotels()
        {
            var hotels = Mapper.Map<IEnumerable<Hotel>>(_hotelRepository.GetHotels());
            return hotels;
        }
    }
}
