using FengShui.Data;
using FengShui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Services
{
    public class AmbienceService
    {
        private readonly Guid _userId;

        public AmbienceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAmbience(AmbienceCreate model)
        {
            var entity =
                new Ambience()
                {
                    AdminId = _userId,
                    AmbienceName = model.AmbienceName,
                    AmbienceDesription = model.AmbienceDesription,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ambiences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<AmbienceList> GetAmbiences()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Ambiences
                        .Where(e => e.AdminId == _userId)
                        .Select(
                        e =>
                            new AmbienceList
                            {
                                AmbienceId = e.AmbienceId,
                                AmbienceName = e.AmbienceName
                            }
                        );
                return query.ToArray();
            }
        }

        public AmbienceDetail GetAmbienceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ambiences
                    .Single(e => e.AmbienceId == id && e.AdminId == _userId);
                return
                    new AmbienceDetail
                    {
                        AmbienceId = entity.AmbienceId,
                        AmbienceName = entity.AmbienceName,
                        AmbienceDesription = entity.AmbienceDesription,
                        ProductCount = entity.ListOfProducts.Count,
                    };
            }
        }

        public bool UpdateAmbience(AmbienceEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Ambiences
                        .Single(e => e.AmbienceId == model.AmbienceId && e.AdminId == _userId);
                entity.AmbienceName = model.AmbienceName;
                entity.AmbienceDesription = model.AmbienceDesription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAmbience(int ambienceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Ambiences
                    .Single(e => e.AmbienceId == ambienceId && e.AdminId == _userId);

                ctx.Ambiences.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductAmbienceDetail> GetAllProductsByAmbienceId(int ambienceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var foundItems =
               ctx.Ambiences.Single(e => e.AmbienceId == ambienceId).ListOfProducts
               .Select(e => new ProductAmbienceDetail
               {
                   ProductId = e.ProductId,
                   ProductName = e.ProductName,
                   Price = e.Price,
                   Brandname = e.Brandname

               }
               );
                return foundItems.ToArray();
            }

        }
    }
}
