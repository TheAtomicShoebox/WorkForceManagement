using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Models.RoleModels
{
    public class RoleCreate : IValidatableObject
    {
        [Required]
        public string RoleName { get; set; }

        [Required]
        public string RoleDescription { get; set; }

        [Required]
        public double BaseRate { get; set; }

        [Required]
        public bool IsSupervisor { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (BaseRate < 0)
            {
                yield return new ValidationResult("BaseRate cannot be less than 0", new[] { nameof(BaseRate) });
            }
            if (BaseRate == 0)
            {
                yield return new ValidationResult("BaseRate cannot be 0", new[] { nameof(BaseRate) });
            }
        }
    }
}
