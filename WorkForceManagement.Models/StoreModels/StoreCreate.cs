using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Models.StoreModels
{
    public class StoreCreate : IValidatableObject
    {
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string StreetAddress { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int result;
            int.TryParse(StoreName, out result);
            if (result != 0)
            {
                yield return new ValidationResult("StoreName cannot be a number.", new[] { nameof(StoreName) });
            }
        }
    }
}
