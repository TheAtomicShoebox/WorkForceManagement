namespace WorkForceManagement.Models.EmployeeModels
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public int StoreLocationId { get; set; }
        public string StoreName { get; set; }

        public double PayRate { get; set; }
        public bool IsActive { get; set; }
    }
}
