using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkForceManagement.Data;
using WorkForceManagement.Models;
using WorkForceManagement.Models.RoleModels;

namespace WorkForceManagement.Services
{
    public class RoleService
    {
        private readonly Guid _userId;

        public RoleService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateRole(RoleCreate model)
        {
            var role = new EmployeeRole()
            {
                RoleName = model.RoleName,
                RoleDescription = model.RoleDescription,
                BaseRate = model.BaseRate,
                IsSupervisor = model.isSupervisor
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.EmployeeRoles.Add(role);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<RoleListItem> GetRoles()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .EmployeeRoles
                    .Select(
                        e =>
                            new RoleListItem
                            {
                                RoleId = e.RoleId,
                                RoleName = e.RoleName,
                            }
                            );

                return query.ToArray();
            }
        }
    }
}
