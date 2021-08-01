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
                    .Single(e => e.AmbienceId == id);
                return
                    new AmbienceDetail
                    {
                        AmbienceId = entity.AmbienceId,
                        AmbienceName = entity.AmbienceName,
                        AmbienceDesription = entity.AmbienceDesription,
                        
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
                        .Single(e => e.AmbienceId == model.AmbienceId);
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
                    .Single(e => e.AmbienceId == ambienceId);

                ctx.Ambiences.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

       /* public IEnumerable<ProductAmbienceDetail> GetAllProductsByAmbienceId(int ambienceId)
        {
            using(var ctx = new ApplicationDbContext)
            {
                var foundItems =
               ctx.ProductAmbiences.Single(e => e.AmbienceId == ambienceId).ProductId
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

        } */
    }
}
