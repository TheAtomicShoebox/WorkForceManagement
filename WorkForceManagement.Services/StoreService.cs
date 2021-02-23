using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WorkForceManagement.Data;
using WorkForceManagement.Models;
using WorkForceManagement.Models.StoreModels;
using StoreLocation = WorkForceManagement.Data.StoreLocation;

namespace WorkForceManagement.Services
{
    public class StoreService
    {
        private readonly Guid _userId;

        public StoreService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateStore(StoreCreate model)
        {
            var entity =
                new StoreLocation()
                {
                    StoreName = model.StoreName,
                    StreetAddress = model.StreetAddress
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.StoreLocations.Add(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        public IEnumerable<StoreListItem> GetStores()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .StoreLocations
                        .Select(
                            e =>
                                new StoreListItem
                                {
                                    StoreNumber = e.StoreNumber,
                                    StoreName = e.StoreName,
                                    StreeAddress = e.StreetAddress
                                }

                        );

                return query.ToArray();
            }
        }

        public StoreDetail GetStoreByNumber(int number)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StoreLocations
                        .Single(e => e.StoreNumber == number);
                return
                    new StoreDetail
                    {
                        StoreNumber = entity.StoreNumber,
                        StoreName = entity.StoreName,
                        StreetAddress = entity.StreetAddress
                    };


            }
        }

        public bool UpdateStore(StoreEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StoreLocations
                        .Single(e => e.StoreNumber == model.StoreNumber);

                entity.StoreName = model.StoreName;
                entity.StreetAddress = model.StreetAddress;

                return ctx.SaveChanges() == 1;
            }
        }
         
        
        public bool DeleteStore(int storeNumber)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .StoreLocations
                        .Single(e => e.StoreNumber == storeNumber);

                ctx.StoreLocations.Remove(entity);

                return ctx.SaveChanges() == 1;

            }
        }
    }
}
