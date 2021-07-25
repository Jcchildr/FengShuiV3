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
    public class AmbienceController : Controller
    {
        // GET: Ambience
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AmbienceService(userId);
            var model = service.GetAmbiences();
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
        public ActionResult Create(AmbienceCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAmbienceService();

            if (service.CreateAmbience(model))
            {
                TempData["SaveResult"] = "The Ambience was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ambience could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateAmbienceService();
            var model = svc.GetAmbienceById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAmbienceService();
            var detail = service.GetAmbienceById(id);
            var model =
                new AmbienceEdit
                {
                    AmbienceId = detail.AmbienceId,
                    AmbienceName = detail.AmbienceName,
                    AmbienceDesription = detail.AmbienceDesription,

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AmbienceEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.AmbienceId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateAmbienceService();

            if (service.UpdateAmbience(model))
            {
                TempData["SaveResult"] = "The Ambience was updated.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Ambience could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAmbienceService();
            var model = svc.GetAmbienceById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAmbienceService();

            service.DeleteAmbience(id);

            TempData["SaveResult"] = "The Ambience was deleted.";

            return RedirectToAction("Index");
        }


        private AmbienceService CreateAmbienceService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AmbienceService(userId);
            return service;
        }

    }
}