using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HAA.API.Models
{
    public class HotelModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage ="Name field is required")]
        [MaxLength(60,ErrorMessage ="Name: Maximum 30 characters")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Address field is required")]
        [MaxLength(120, ErrorMessage = "Address: Maximum 120 characters")]
        public string Address { get; set; }


        [Required(ErrorMessage = "City field is required")]
        [MaxLength(50, ErrorMessage = "City: Maximum 50 characters")]
        public string City { get; set; }


        [Required(ErrorMessage = "Pincode field is required")]
        [MinLength(6,ErrorMessage ="Enter 6 digit PinCode")]
        [MaxLength(6, ErrorMessage = "Enter 6 digit PinCode")]
        public string Pincode { get; set; }


        [Required(ErrorMessage = "ContactNumber field is required")]
        [MinLength(10, ErrorMessage = "Enter 10 digit PinCode")]
        [MaxLength(10, ErrorMessage = "Enter 10 digit PinCode")]
        public string ContactNumber { get; set; }


        [Required(ErrorMessage = "ContactPerson field is required")]
        [MaxLength(40, ErrorMessage = "ContactPerson: Maximum 40 characters")]
        public string ContactPerson { get; set; }
       
        
        public string Website { get; set; }
        
        
        public string Facebook { get; set; }
        
        
        public string Twitter { get; set; }


        [Required(ErrorMessage = "IsActive is required (true/false)")]
        public bool IsActive { get; set; }
        
        
        public DateTime CreatedDate { get; set; }


        [Required(ErrorMessage = "CreatedBy is required ")]
        public string CreatedBy { get; set; }
        
        
        public DateTime UpdatedDate { get; set; }


        [Required(ErrorMessage = "UpdatedBy is required ")]
        public string UpdatedBy { get; set; }


        public virtual ICollection<RoomModel> Rooms { get; set; }
    }
}