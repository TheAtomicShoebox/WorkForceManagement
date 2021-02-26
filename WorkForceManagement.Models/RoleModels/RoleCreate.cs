using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Models.RoleModels
{
    public class RoleCreate
    {
        [Required]
        public string RoleName { get; set; }

        [Required]
        public string RoleDescription { get; set; }

        [Required]
        public double BaseRate { get; set; }

        [Required]
        public bool IsSupervisor { get; set; }
    }
}
