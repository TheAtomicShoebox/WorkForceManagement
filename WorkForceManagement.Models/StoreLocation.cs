using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkForceManagement.Models
{
    public class StoreLocation
    {
        [Key]
        public int StoreNumber { get; set; }
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
