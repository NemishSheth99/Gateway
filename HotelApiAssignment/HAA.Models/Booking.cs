using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.Models
{
    public class Booking
    { 
        public int Id { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; }
        public BookingStatusEnum BookingStatus { get; set; }

        public virtual Room Room { get; set; }
    }
}
