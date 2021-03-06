using FengShui.Data;
using FengShui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FengShui.Services
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    Brandname = model.Brandname,
                    Height = model.Height,
                    Length = model.Length,
                    Width = model.Width,
                    NumberInStock = model.NumberInStock,
                    ProductDescription = model.ProductDescription,
                    CategoryId = model.CategoryId,
                    HomeLocation = model.HomeLocation,
                    PrimaryColor = model.PrimaryColor,
                    SecondaryColor = model.SecondaryColor,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }


        public IEnumerable<ProductList> GetProducts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Products
                        .Select(
                        p =>
                            new ProductList
                            {
                                ProductId = p.ProductId,
                                ProductName = p.ProductName,
                                Price = p.Price,
                                Brandname = p.Brandname,
                            }
                        );
                return query.ToArray();
            }
        }

        public ProductDetail GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(p => p.ProductId == id);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        ProductName = entity.ProductName,
                        Price = entity.Price,
                        Brandname = entity.Brandname,
                        Dimension = entity.Dimension,
                        NumberInStock = entity.NumberInStock,
                        ProductDescription = entity.ProductDescription,
                        CategoryName = entity.Category.CategoryName,
                        HomeLocation = entity.HomeLocation,
                        PrimaryColor = entity.PrimaryColor,
                        SecondaryColor = entity.SecondaryColor,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        //Made so the progam will remember the Height,Length and Width when editing
        public ProductDetail EditProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(p => p.ProductId == id);
                return
                    new ProductDetail
                    {
                        ProductId = entity.ProductId,
                        ProductName = entity.ProductName,
                        Price = entity.Price,
                        Brandname = entity.Brandname,
                        Height = entity.Height,
                        Length = entity.Length,
                        Width = entity.Width,
                        NumberInStock = entity.NumberInStock,
                        ProductDescription = entity.ProductDescription,
                        CategoryName = entity.Category.CategoryName,
                        HomeLocation = entity.HomeLocation,
                        PrimaryColor = entity.PrimaryColor,
                        SecondaryColor = entity.SecondaryColor,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Products
                        .Single(p => p.ProductId == model.ProductId);
                entity.ProductName = model.ProductName;
                entity.Price = model.Price;
                entity.Brandname = model.Brandname;
                entity.Height = model.Height;
                entity.Width = model.Width;
                entity.Length = model.Length;
                entity.NumberInStock = model.NumberInStock;
                entity.ProductDescription = model.ProductDescription;
                entity.CategoryId = model.CategoryId;
                entity.HomeLocation = model.HomeLocation;
                entity.PrimaryColor = model.PrimaryColor;
                entity.SecondaryColor = model.SecondaryColor;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProduct(int productId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(p => p.ProductId == productId);

                ctx.Products.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<Product> Products()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Products.ToList();
            }
        }
    }
}
