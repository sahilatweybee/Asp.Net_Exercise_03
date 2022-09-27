using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net_Exercise_03.Helpers
{
    public class ListCustomValidator : ValidationAttribute
    {
        public ListCustomValidator(string text)
        {
            Text = text;
        }
        public string Text { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string id = value.ToString();
                if (!id.Equals(Text) || id == null)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage = "BookName does not contain the desired value");
        }
    }
}
