namespace WorkForceManagement.Models.EmployeeModels
{
    public class EmployeeDetail
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public int StoreLocationId { get; set; }
        public string StoreName { get; set; }
    }
}
