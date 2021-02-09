using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SourceControl.CustomValidations
{
    public class GenderValidation:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            List<char> genders = new List<char>(){ 'M', 'F', 'O'};
            return genders.Contains(Convert.ToChar(value));
        }
    }
}