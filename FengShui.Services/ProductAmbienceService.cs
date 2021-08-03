using FengShui.Data;
using FengShui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Services
{
    public class ProductAmbienceService
    {
        private readonly Guid _userId;

        public ProductAmbienceService(Guid userId)
        {
            _userId = userId;
        }
        public bool AddAmbienceToProduct(ProductAmbienceCreate model)
        {
            var entity =
                 new ProductAmbience()
                 {
                     ProductId = model.ProductId,
                     AmbienceId = model.AmbienceId,
                 };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductAmbiences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProductAmbienceList> GetProductAmbienceList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ProductAmbiences
                        .Select(
                        pa =>
                            new ProductAmbienceList
                            {
                                ProductId = pa.ProductId,
                                ProductName = pa.Product.ProductName,
                                AmbienceId = pa.AmbienceId,
                                AmbienceName = pa.Ambience.AmbienceName,
                            }
                        );
                return query.ToArray();
            }
        }

        public IEnumerable<ProductAmbienceDetail> GetAllProductsByAmbienceId( int ambienceId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.ProductAmbiences.Where(pa => pa.AmbienceId == ambienceId)
                    .Select(pa => new ProductAmbienceDetail
                    {
                       
                        ProductId = pa.Product.ProductId,
                        ProductName = pa.Product.ProductName,
                        Price = pa.Product.Price,
                        Brandname = pa.Product.Brandname,

                    }
               );
                return query.ToArray();
            } 
        }

        public bool DeleteThePALink(int ambienceId, int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProductAmbiences
                    .Where(pa => pa.AmbienceId == ambienceId && pa.ProductId == productId);

                ctx.ProductAmbiences.Remove((ProductAmbience)entity);
                return ctx.SaveChanges() == 1;
            }
        }


        /*  
                public ProductAmbienceList GetProductAmbienceId(int id)
                {
                    using (var ctx = new ApplicationDbContext())
                    {
                        var entity =
                            ctx
                            .ProductAmbiences
                            .Single(p => p.ProductAmbienceId == id && p.AdminId == _userId);
                        return
                            new ProductAmbienceList
                            {
                                ProductAmbienceId = entity.ProductAmbienceId,
                                ProductId = entity.ProductId,
                                AmbienceId = entity.AmbienceId,
                            };
                    }
                }

           /*    public bool UpdateProductAmbience (ProductAmbienceEdit model)
                {
                    using (var ctx = new ApplicationDbContext())
                    {
                        var entity =
                            ctx
                                .ProductAmbiences
                                .Single(pa => pa.ProductAmbienceId == model.ProductAmbienceId && pa.AdminId == _userId);
                        entity.ProductId = model.ProductId;
                        entity.AmbienceId = model.AmbienceId;

                        return ctx.SaveChanges() == 1;

                    }

                }*/

    }



}