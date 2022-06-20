using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartProject
{
    internal class ValidTestAttribute : ValidationAttribute
    {
        public ValidTestAttribute() { }

        public ValidTestAttribute(params string[] r)
        {

        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || value.GetType() != typeof(DateTime))
                throw new ArgumentException();

            DateTime date = (DateTime)value;

            if (date > DateTime.Now.Date)
                return ValidationResult.Success;

            return new ValidationResult("must be in the future");
        }
    }
}
