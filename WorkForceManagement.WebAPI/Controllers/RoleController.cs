using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.ApplicationServices;
using System.Web.Http;

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
        }
    }
}
