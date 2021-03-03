using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Data
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
