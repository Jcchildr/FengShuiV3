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
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductCategoryService(userId);
            var model = service.GetAllProductCategories();
            return View(model);
        }

        //Get
        public ActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductCategoryService();

            if (service.CreateProductCategory(model))
            {
                TempData["SaveResult"] = "The category was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProductCategoryService();
            var model = svc.GetProductCategoryById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProductCategoryService();
            var detail = service.GetProductCategoryById(id);
            var model =
                new ProductCategoryEdit
                {
                    ProductCategoryId = detail.ProductCategoryId,
                    ProductCategoryName = detail.ProductCategoryName,
                    ProductCategoryDesc = detail.ProductCategoryDesc
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductCategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProductCategoryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateProductCategoryService();

            if (service.UpdateProductCategory(model))
            {
                TempData["SaveResult"] = "The category was updated.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Category could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProductCategoryService();
            var model = svc.GetProductCategoryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProductCategoryService();

            service.DeleteProductCategory(id);

            TempData["SaveResult"] = "The category was deleted.";

            return RedirectToAction("Index");
        }


        private ProductCategoryService CreateProductCategoryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductCategoryService(userId);
            return service;
        }

    }
}