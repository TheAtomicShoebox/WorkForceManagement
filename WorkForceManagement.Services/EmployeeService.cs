using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkForceManagement.Data;
using WorkForceManagement.Models.EmployeeModels;

namespace WorkForceManagement.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }

        public async Task<bool> CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RoleId = model.RoleId,
                    StoreLocationId = model.StoreLocationId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return await ctx.SaveChangesAsync() == 1;
            }
        }

        public async Task<IEnumerable<EmployeeDetail>> GetEmployees()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                        .Select(
                        e =>
                        new EmployeeDetail
                        {
                            EmployeeId = e.EmployeeId,
                            FullName = e.FullName,
                            RoleId = e.RoleId,
                            RoleName = e.Role.RoleName,
                            StoreLocationId = e.StoreLocationId,
                            StoreName = e.EmployeeLocation.StoreName
                        });

                return await query.ToArrayAsync();
            }
        }

        public async Task<EmployeeDetail> GetEmployeeById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = await
                    ctx
                        .Employees
                        .SingleAsync(e => e.EmployeeId == id);
                return new EmployeeDetail
                {
                    EmployeeId = entity.EmployeeId,
                    FullName = entity.FullName,
                    RoleId = entity.RoleId,
                    RoleName = entity.Role.RoleName,
                    StoreLocationId = entity.StoreLocationId,
                    StoreName = entity.EmployeeLocation.StoreName
                };
            }
        }
    }
}
