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
        public async Task<IHttpActionResult> Get()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employees = await employeeService.GetEmployees();
            return Ok(employees);
        }

        // GET by id api/Employee/:employeeId
        public async Task<IHttpActionResult> Get(int id)
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employee = await employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

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

        // PUT api/Employee/:employeeID
        public async Task<IHttpActionResult> Terminate(int id)
        {
            EmployeeService employeeService = CreateEmployeeService();

            if (await employeeService.TerminateEmployeeById(id))
                return Ok();

            return InternalServerError();
        }
    }
}