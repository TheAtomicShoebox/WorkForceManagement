using System;
using System.Collections.Generic;
using System.Linq;
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
                IsSupervisor = model.IsSupervisor
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

        public RoleDetail GetRoleById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EmployeeRoles
                        .Single(e => e.RoleId == id);
                return
                    new RoleDetail
                    {
                        RoleId = entity.RoleId,
                        RoleName = entity.RoleName,
                        RoleDescription = entity.RoleDescription,
                        BaseRate = entity.BaseRate,
                        IsSupervisor = entity.IsSupervisor
                    };
            }
        }

        public bool UpdateRole(RoleEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EmployeeRoles
                        .Single(e => e.RoleId == model.RoleId);

                entity.RoleId = model.RoleId;
                entity.RoleDescription = model.RoleDescription;
                entity.RoleName = model.RoleName;
                entity.BaseRate = model.BaseRate;
                entity.IsSupervisor = model.IsSupervisor;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteRole(int roleId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .EmployeeRoles
                        .Single(e => e.RoleId == roleId);

                ctx.EmployeeRoles.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
