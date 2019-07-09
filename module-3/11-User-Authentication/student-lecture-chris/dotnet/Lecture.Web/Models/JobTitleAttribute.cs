using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    public class JobTitleAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _title;

        public JobTitleAttribute(string title)
        {
            _title = title;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;

            // We can only use this attribute on Movies so cast to a Movie first.
            string title = (string)value;

            // Once casted, the object can now be checked for the rules.
            if (title != _title)
            {
                result = new ValidationResult($"Gotta be the Prez");
            }

            return result;
        }
    }
}
