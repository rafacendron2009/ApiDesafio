
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api_2.Resources
{
    public class CalculatesInterestQueryResource : IValidatableObject
    {
        [Required]
        public double valorinicial { get; set; }

        [Required]
        public int meses { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
             var result = new List<ValidationResult>();

            if(meses == 0)
            {
                result.Add(new ValidationResult("Numero de meses tem que ser maior que 0"));
            }

            return result;
        }
    };

}