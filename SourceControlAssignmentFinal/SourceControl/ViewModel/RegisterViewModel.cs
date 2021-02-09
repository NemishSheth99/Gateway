using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControl.ViewModel
{
    public class RegisterViewModel
    {
        public int Id { get; set; }


        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [DisplayName("Email Id")]
        public string EmailId { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }


        [DisplayName("User Name")]
        public string Name { get; set; }
    }
}