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
    public class ProductAmbienceController : Controller
    {
        // GET: ProductAmbience
        public ActionResult Index()
        {
            var service = CreateProductAmbienceService();
            var model = service.GetProductAmbienceList();
            return View(model);
        }


        public ActionResult Create()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            ViewBag.ProductList = new ProductService(userId).GetProducts();
            ViewBag.AmbienceList = new AmbienceService(userId).GetAmbiences();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAmbienceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProductAmbienceService();

            if (service.AddAmbienceToProduct(model))
            {
                TempData["SaveResult"] = "The Link was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Link could not be created.");
            return View(model);
        }

        public ActionResult PADetails(int id)
        {

            var svc = CreateProductAmbienceService();
            var model = svc.GetAllProductsByAmbienceId(id);

            return View(model);
        }
        /*
                public ActionResult Edit(int id)
                {
                    var service = CreateProductAmbienceService();
                    var userId = Guid.Parse(User.Identity.GetUserId());
                    ViewBag.ProductList = new ProductService(userId).GetProducts();
                    ViewBag.AmbienceList = new AmbienceService(userId).GetAmbiences();
                    var detail = service.GetProductAmbienceId(id);
                    var model =
                        new ProductAmbienceEdit
                        {
                            ProductId = detail.ProductId,
                            AmbienceId = detail.AmbienceId,
                        };
                    return View(model);
                }

                [HttpPost]
                [ValidateAntiForgeryToken]
                public ActionResult Edit(int id, ProductAmbienceEdit model)
                {
                    if (!ModelState.IsValid) return View(model);

                    if (model.ProductAmbienceId != id)
                    {
                        ModelState.AddModelError("", "Id Mismatch");
                        return View(model);
                    }
                    var service = CreateProductAmbienceService();

                    if (service.UpdateProductAmbience(model))
                    {
                        TempData["SaveResult"] = "The Link was updated.";
                        return RedirectToAction("Index");
                    };

                    ModelState.AddModelError("", "Link could not be updated.");
                    return View();
                }
        */
        private ProductAmbienceService CreateProductAmbienceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProductAmbienceService(userId);
            return service;
        }
    }
}