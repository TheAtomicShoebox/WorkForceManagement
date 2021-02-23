using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Models.RoleModels
{
    public class RoleEdit
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public double BaseRate { get; set; }
        public bool IsSupervisor { get; set; }
    }
}
