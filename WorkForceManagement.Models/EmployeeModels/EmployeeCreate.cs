using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Models.EmployeeModels
{
    public class EmployeeCreate
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
    }
}
