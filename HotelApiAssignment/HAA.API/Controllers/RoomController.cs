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
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        private readonly IRoomManager _roomManager;
         
        public RoomController(IRoomManager roomManager)
        {
            _roomManager = roomManager;
        }



        [HttpGet] 
        [Route()]
        public IHttpActionResult GetRoom(string city, string pincode,decimal? price, byte? category)
        {
            var rooms = Mapper.Map<IEnumerable<RoomModel>>(_roomManager.GetRooms(city,pincode,price,category));
            return Ok(rooms);
        }


        [HttpPost]
        public IHttpActionResult CreateRoom(RoomModel room)
        {
            if (ModelState.IsValid)
            {
                var roomObj = Mapper.Map<Room>(room);
                room.Id = _roomManager.CreateRoom(roomObj);
                if (room.Id > 0)
                {
                    return Created("", room);
                }
            }
            return BadRequest();
            
        }
    }
}
