using FengShui.Data;
using FengShui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Services
{
    public class ProductCategoryService
    {
        private readonly Guid _userId;

        public ProductCategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProductCategory(ProductCategoryCreate model)
        {
            var entity =
                new ProductCategory()
                {
                    AdminId = _userId,
                    ProductCategoryName = model.ProductCategoryName,
                    ProductCategoryDesc = model.ProductCategoryDesc
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.ProductCategories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductCategoryList> GetAllProductCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .ProductCategories
                        .Where(e => e.AdminId == _userId)
                        .Select(
                        e =>
                            new ProductCategoryList
                            {
                                ProductCategoryId = e.ProductCategoryId,
                                ProductCategoryName = e.ProductCategoryName
                            }
                        );
                return query.ToArray();
            }
        }

        public ProductCategoryDetail GetProductCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProductCategories
                    .Single(e => e.ProductCategoryId == id && e.AdminId == _userId);
                return
                    new ProductCategoryDetail
                    {
                        ProductCategoryId = entity.ProductCategoryId,
                        ProductCategoryName = entity.ProductCategoryName,
                        ProductCategoryDesc = entity.ProductCategoryDesc

                    };
            }
        }

        public bool UpdateProductCategory(ProductCategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .ProductCategories
                        .Single(e => e.ProductCategoryId == model.ProductCategoryId && e.AdminId == _userId);
                entity.ProductCategoryName = model.ProductCategoryName;
                entity.ProductCategoryDesc = model.ProductCategoryDesc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProductCategory(int productCategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .ProductCategories
                    .Single(e => e.ProductCategoryId == productCategoryId && e.AdminId == _userId);

                ctx.ProductCategories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
