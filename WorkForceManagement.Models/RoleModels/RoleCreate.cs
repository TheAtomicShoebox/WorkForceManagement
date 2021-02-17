using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool isSupervisor { get; set; }
    }
}
