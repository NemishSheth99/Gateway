using CP.WebAPI.Models;
using CP.WebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CP.WebAPI.Controllers
{
    public class PassengerController : ApiController
    {
        private readonly IDataRepository _dataRepository;

        public PassengerController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var passenger = _dataRepository.GetPassengerById(id);
            if (passenger == null) return NotFound();
            else return Ok(passenger);
        }
        [HttpGet]
        public List<PassengerModel> Get()
        {
            return _dataRepository.GetAllPassenger();
        }

        public bool Delete(int id)
        {
            return _dataRepository.DeletePassenger(id);
        }

        [HttpPost]
        public PassengerModel Add(PassengerModel passenger)
        {
            return _dataRepository.AddPassenger(passenger);
            
        }
        [HttpPut]
        public PassengerModel Put(PassengerModel passenger)
        {
            return _dataRepository.AddPassenger(passenger);
        }
    }
}
