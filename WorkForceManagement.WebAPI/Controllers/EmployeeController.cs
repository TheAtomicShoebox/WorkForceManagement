using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using System.Web.Http;
using WorkForceManagement.Models.EmployeeModels;
using WorkForceManagement.Services;

namespace WorkForceManagement.WebAPI.Controllers
{
    [Authorize]
    public class EmployeeController : ApiController
    {
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var employeeService = new EmployeeService(userId);
            return employeeService;
        }

        [HttpGet]
        [Route("api/Employee/")]
        public async Task<IHttpActionResult> Get()
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employees = await employeeService.GetEmployees();
            return Ok(employees);
        }

        [HttpGet]
        [Route("api/Employee/{id}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            EmployeeService employeeService = CreateEmployeeService();
            var employee = await employeeService.GetEmployeeById(id);
            return Ok(employee);
        }

        [HttpPost]
        [Route("api/Employee/")]
        public async Task<IHttpActionResult> Post(EmployeeCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateEmployeeService();

            if (await service.CreateEmployee(model) != true)
                return InternalServerError();

            return Ok();
        }

        [Route("api/Employee/ChangeEmployeeStatus/{id}")]
        [HttpPut]
        public async Task<IHttpActionResult> ChangeEmployeeStatus(int id)
        {
            EmployeeService employeeService = CreateEmployeeService();

            if (await employeeService.ChangeEmployeeStatusById(id))
                return Ok();

            return InternalServerError();
        }

        [HttpPut]
        [Route("api/Employee")]
        public async Task<IHttpActionResult> Update(EmployeeDetail model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            EmployeeService employeeService = CreateEmployeeService();

            if (await employeeService.UpdateEmployee(model))
                return Ok();

            return InternalServerError();
        }
    }
}