using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorkForceManagement.Models;
using WorkForceManagement.Models.StoreModels;
using WorkForceManagement.Services;

namespace WorkForceManagement.WebAPI.Controllers
{
    [Authorize]
    public class StoreController : ApiController
    {
       
        [HttpGet]
        public IHttpActionResult Get()
        {
            StoreService storeService = CreateStoreService();
            var stores = storeService.GetStores();
            return Ok(stores);
        }

        [HttpPost]
        public IHttpActionResult Post(StoreCreate store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStoreService();

            if (!service.CreateStore(store))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get(int number)
        {
            StoreService storeService = CreateStoreService();
            var store = storeService.GetStoreByNumber(number);
            return Ok(store);
        }

        [HttpPut]
        public IHttpActionResult Put(StoreEdit store)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateStoreService();

            if (!service.UpdateStore(store))
                return InternalServerError();

            return Ok();
        }

        [HttpDelete]
        [Route("api/Store/{storeNumber}")]
        public IHttpActionResult Delete(int storeNumber)
        {
            var service = CreateStoreService();

            if (!service.DeleteStore(storeNumber))
                return InternalServerError();

            return Ok();
        }

        private StoreService CreateStoreService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var storeService = new StoreService(userId);
            return storeService;
        }
    }
}

