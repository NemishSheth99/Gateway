using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControl.CustomValidations
{
    public class MaxAge18 : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var today = DateTime.Today;
            DateTime birthDate = Convert.ToDateTime(value);
            // Calculate the age.
            var age = today.Year - birthDate.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age >= 18;
        }
    }
}