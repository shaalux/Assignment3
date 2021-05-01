using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Courses.Models
{
    public class MaximumCreditSize : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var course = (Course)validationContext.ObjectInstance;

            if (course.Credits < 20)
                return ValidationResult.Success;
            else
                return new ValidationResult("The Number of credits must be 15 or less");
        }
    }
}