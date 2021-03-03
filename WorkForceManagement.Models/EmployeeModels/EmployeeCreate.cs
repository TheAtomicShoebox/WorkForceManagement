using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Models.EmployeeModels
{
    public class EmployeeCreate : IValidatableObject
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int StoreLocationId { get; set; }

        public double PayRate { get; set; }

        public bool IsActive { get; set; } = true;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PayRate < 0)
            {
                yield return new ValidationResult("PayRate cannot be less than 0", new[] { nameof(PayRate) });
            }
            if (PayRate == 0)
            {
                yield return new ValidationResult("PayRate cannot be 0", new[] { nameof(PayRate) });
            }
        }
    }
}
