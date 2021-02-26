using System.ComponentModel.DataAnnotations;

namespace WorkForceManagement.Models.StoreModels
{
    public class StoreCreate
    {
        [Required]
        public string StoreName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
    }
}
