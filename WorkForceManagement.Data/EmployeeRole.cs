using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Data
{
    public class EmployeeRole
    {
        [Key]
        public int RoleId { get; set; }

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
