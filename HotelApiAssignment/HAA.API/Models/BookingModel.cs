using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HAA.API.Models
{
    public class BookingModel
    {
        public int Id { get; set; }


        [Required]
        public int RoomId { get; set; }


        [Required, DataType(DataType.Date)]
        public DateTime BookingDate { get; set; }


        [Required(ErrorMessage = "BookingStatus: Optional, Definitive, Cancelled, Deleted")]
        public BookingStatusEnum BookingStatus { get; set; }

        public virtual RoomModel Room { get; set; }
    }
}