using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ApplicationServices;
using System.Web.Http;
using WorkForceManagement.Models.RoleModels;
using RoleService = WorkForceManagement.Services.RoleService;

namespace WorkForceManagement.WebAPI.Controllers
{
    [Authorize]
    public class RoleController : ApiController
    {
       private RoleService CreateRoleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var roleService = new RoleService(userId);
            return roleService;
        }

        public IHttpActionResult Get()
        {
            RoleService roleService = CreateRoleService();
            var roles = roleService.GetRoles();
            return Ok(roles);
        }

        public IHttpActionResult Get(int id)
        {
            RoleService roleService = CreateRoleService();
            var role = roleService.GetRoleById(id);
            return Ok(role);
        }

        public IHttpActionResult Post(RoleCreate role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoleService();

            if (!service.CreateRole(role))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(RoleEdit role)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateRoleService();

            if (!service.UpdateRole(role))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateRoleService();

            if (!service.DeleteRole(id))
                return InternalServerError();

            return Ok();
        }
    }
}
