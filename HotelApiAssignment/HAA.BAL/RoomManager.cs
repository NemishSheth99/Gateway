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
    public class RoomManager : IRoomManager
    {
        private IRoomRepository _roomRepository;
         
        public RoomManager(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
         

        public int CreateRoom(Room room)
        {
            room.CreatedDate = DateTime.Now.Date;
            var roomObj = Mapper.Map<tblRoom>(room);
            //roomObj.RoomCategory = (byte)room.RoomCategory;
            return _roomRepository.CreateRoom(roomObj);
        }


        public bool CreateRooms(IEnumerable<Room> rooms)
        {
            
            var roomsList = Mapper.Map<IEnumerable<tblRoom>>(rooms);
            return _roomRepository.CreateRooms(roomsList);
        }


        public IEnumerable<Room> GetRooms(string city, string pincode, decimal? price, byte? category)
        {
            var result = _roomRepository.GetRooms(city, pincode, price, category);

            IEnumerable<Room> roomList = Mapper.Map<IEnumerable<Room>>(result);
            return roomList;
        }
    }
}
