using FengShui.Data;
using FengShui.Models;
using FengShui.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FengShuiV3.WebMVC.Controllers
{
    [Authorize]//Allows only Loged in individuals to access page

    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var service = CreateProductService();
            var model = service.GetProducts();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            ViewBag.CategoryList = new CategoryService(userId).GetCategories();
            return View();
        }


        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductService();

            if (service.CreateProduct(model))
            {
                TempData["SaveResult"] = "The product was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.EditProductById(id);
            var model =
                new ProductEdit
                {
                    ProductId = detail.ProductId,
                    ProductName = detail.ProductName,
                    Price = detail.Price,
                    Brandname = detail.Brandname,
                    Height = detail.Height,
                    Width = detail.Width,
                    Length = detail.Length,
                    NumberInStock = detail.NumberInStock,
                    ProductDescription = detail.ProductDescription,
                    CategoryId = detail.CategoryId,
                    HomeLocation = detail.HomeLocation,
                    PrimaryColor = detail.PrimaryColor,
                    SecondaryColor = detail.SecondaryColor,
                };
            var userId = Guid.Parse(User.Identity.GetUserId());
            ViewBag.CategoryList = new CategoryService(userId).GetCategories();
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateProductService();

            if (service.UpdateProduct(model))
            {
                TempData["SaveResult"] = "The product was updated.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Product could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductService();

            service.DeleteProduct(id);

            TempData["SaveResult"] = "The product was deleted.";

            return RedirectToAction("Index");
        }


        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductService(userId);
            return service;
        }


    }
}