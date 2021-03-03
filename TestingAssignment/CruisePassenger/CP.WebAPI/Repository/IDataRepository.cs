using CP.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.WebAPI.Repository
{
    public interface IDataRepository
    {
        PassengerModel GetPassengerById(int id);
        List<PassengerModel> GetAllPassenger();
        PassengerModel AddPassenger(PassengerModel passenger);
        PassengerModel UpdatePassenger(PassengerModel passenger);
        bool DeletePassenger(int id);

    }
}