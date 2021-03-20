using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HAA.API.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage ="HotelId is required")]
        

        public int HotelId { get; set; }


        [Required(ErrorMessage = "RoomName is required")]
        [MaxLength(20,ErrorMessage ="RoomName: Maximum 20 characters")]
        public string RoomName { get; set; }
        
        
        [Required(ErrorMessage = "RoomCategory: Regular,Classic,Premimum")]
        public RoomCategoryEnum RoomCategory { get; set; }
        
        
        [Required, DataType(DataType.Currency)]
        public decimal RoomPrice { get; set; }

       
        [Required(ErrorMessage = "IsActive is required (true/false)")]
        public bool IsActive { get; set; } 
        
        
        public DateTime CreatedDate { get; set; }
        
        
        [Required(ErrorMessage = "CreatedBy is required ")]
        public string CreatedBy { get; set; }
        
        
        public DateTime UpdatedDate { get; set; }
        
        
        [Required(ErrorMessage = "UpdatedBy is required ")]
        public string UpdatedBy { get; set; }

       
        public virtual ICollection<BookingModel> Bookings { get; set; }
        
        
        public virtual HotelModel Hotel { get; set; }
    }
}