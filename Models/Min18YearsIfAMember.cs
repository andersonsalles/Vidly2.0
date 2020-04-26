using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace WebApplication1.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Birth date is required");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be at least 18 years old to go on a membership."));
        }
    }
}