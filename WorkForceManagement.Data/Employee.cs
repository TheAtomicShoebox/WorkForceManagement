using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkForceManagement.Data
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public bool IsActive { get; set; } = true;

        [Required]
        [ForeignKey(nameof(Role))]
        public int RoleId { get; set; }

        public virtual EmployeeRole Role { get; set; }

        [Required]
        [ForeignKey(nameof(EmployeeLocation))]
        public int StoreLocationId { get; set; }

        public virtual StoreLocation EmployeeLocation { get; set; }
    }
}
