using CP.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.WebAPI.Repository
{
    public class DataRepository : IDataRepository
    {
        Dictionary<int,PassengerModel> _passengers = new Dictionary<int, PassengerModel>();

        public DataRepository()
        {
            _passengers.Add( 1, new PassengerModel() { Id = 1, FirstName = "Nemish", LastName = "Sheth", ContactNumber = "9999999999" });
            _passengers.Add( 2, new PassengerModel() { Id = 2, FirstName = "Naimish", LastName = "Sheth", ContactNumber = "8888888888" });
            _passengers.Add( 3, new PassengerModel() { Id = 3, FirstName = "Namish", LastName = "Sheth", ContactNumber = "7777777777" });
        }


        public List<PassengerModel> GetAllPassenger()
        {
            return _passengers.Select(i => i.Value).ToList();
        }


        public PassengerModel GetPassengerById(int id)
        {
            return _passengers.FirstOrDefault(p => p.Value.Id == id).Value;
        }
        
        
        public PassengerModel AddPassenger(PassengerModel passenger)
        {
            var passengerList = GetAllPassenger();
            passenger.Id = passengerList.Any() ? passengerList.Max(i => i.Id) + 1 : 1;
            _passengers.Add(passenger.Id, passenger);
            return passenger;
        }
        
        
        public PassengerModel UpdatePassenger(PassengerModel passenger)
        {
           // var existingPassenger = GetPassengerById(passenger.Id);
            //if (existingPassenger == null) return null;
            //else
            //{
                _passengers[passenger.Id] = passenger;
                return passenger;
            //}
        }


        public bool DeletePassenger(int id)
        {
            return _passengers.Remove(id);
        }
    }
}