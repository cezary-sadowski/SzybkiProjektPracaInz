using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pracainz.Models
{
    public class SpisPracownikowValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var worker = (SpisPracownikow)validationContext.ObjectInstance;

            if (worker.TypPracownika.Equals("Brygadzista"))
                return ValidationResult.Success;

            else
                return new ValidationResult("Typ pracownika możliwy do dodania to Brygadzista");
        }
    }
}