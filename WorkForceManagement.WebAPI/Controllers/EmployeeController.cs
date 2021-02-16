using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using WorkForceManagement.Models.EmployeeModels;
using WorkForceManagement.Services;

namespace WorkForceManagement.WebAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }

        // GET api/Employee

        // GET by id api/Employee/:employeeId

        // POST api/Employee
        public async Task<IHttpActionResult> Post(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployeeService();

            if (await service.CreateEmployee(model) != true)
                return InternalServerError();

            return Ok();
        }
    }
}