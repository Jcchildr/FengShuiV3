using FengShui.Data;
using FengShui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Services
{
    public class CategoryService
    {
        private readonly Guid _userId;

        public CategoryService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCategory(CategoryCreate model)
        {
            var entity =
                new Category()
                {
                    AdminId = _userId,
                    CategoryName = model.CategoryName,
                    CategoryDesc = model.CategoryDesc
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Categories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CategoryList> GetCategories()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Categories
                        .Where(e => e.AdminId == _userId)
                        .Select(
                        e =>
                            new CategoryList
                            {
                                CategoryId = e.CategoryId,
                                CategoryName = e.CategoryName
                            }
                        );
                return query.ToArray();
            }
        }

        public CategoryDetail GetCategoryById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == id && e.AdminId == _userId);
                return
                    new CategoryDetail
                    {
                        CategoryId = entity.CategoryId,
                        CategoryName = entity.CategoryName,
                        CategoryDesc = entity.CategoryDesc

                    };
            }
        }

        public bool UpdateCategory(CategoryEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Categories
                        .Single(e => e.CategoryId == model.CategoryId && e.AdminId == _userId);
                entity.CategoryName = model.CategoryName;
                entity.CategoryDesc = model.CategoryDesc;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCategory(int CategoryId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Categories
                    .Single(e => e.CategoryId == CategoryId && e.AdminId == _userId);

                ctx.Categories.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
