namespace WorkForceManagement.Models.RoleModels
{
    public class RoleDetail
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public double BaseRate { get; set; }

        public bool IsSupervisor { get; set; }
    }
}
