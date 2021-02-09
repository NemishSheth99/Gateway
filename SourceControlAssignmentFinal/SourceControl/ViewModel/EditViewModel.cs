using SourceControl.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControl.ViewModel
{
    public class EditViewModel
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [MaxLength(50)]
        [DisplayName("Email Id")]
        public string EmailId { get; set; }


        [DisplayName("User Name")]
        public string Name { get; set; }


        [DataType(DataType.PhoneNumber)]
        public string ContactNo { get; set; }


        [MinLength(1, ErrorMessage = "Only 1 Char allowed")]
        [StringLength(1, ErrorMessage = "Only 1 Char allowed")]
        [GenderValidation(ErrorMessage = "M / F / O ")]
        public string Gender { get; set; }


        [MaxAge18(ErrorMessage = "Must be 18 years Old")]
        [DisplayName("BirthDate Date")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> BirthDate { get; set; }


        public Nullable<byte> Experience { get; set; }


        [DataType(DataType.ImageUrl)]
        [DisplayName("Image")]
        public string ImagePath { get; set; }


        public HttpPostedFileBase ImageFile { get; set; }
    }
}