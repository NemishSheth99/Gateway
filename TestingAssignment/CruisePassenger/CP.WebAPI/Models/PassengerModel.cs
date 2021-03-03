using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CP.WebAPI.Models
{
    public class PassengerModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
    }
}