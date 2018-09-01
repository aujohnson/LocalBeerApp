using LocalBeer.Models;
using LocalBeer.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocalBeerRaterApp.WebMVC.Controllers
{
    [Authorize]
    public class BreweryController : Controller
    {
        
        
        // GET: Brewery
        public ActionResult Index()
        {

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BreweryService(userId);
            var model = service.GetBreweries();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BreweryCreate brewery)
         {
            if (!ModelState.IsValid)
            {
                return View(brewery);
            }
            var service = CreateBreweryService();

            if (service.CreateBrewery(brewery))
            {
                TempData["SaveResult"] = "Your Brewery was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Brewery could not be created.");

            return View(brewery);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBreweryService();
            var model = svc.GetBreweryById(id);

     return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateBreweryService();
            var detail = service.GetBreweryById(id);
            var model =
                new BreweryEdit
                {
                    BreweryId = detail.BreweryId,
                    BreweryName = detail.BreweryName,
                    BreweryAddress = detail.BreweryAddress,
                    BreweryDescription = detail.BreweryDescription

                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BreweryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BreweryId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBreweryService();

            if (service.UpdateBrewery(model))
            {
                TempData["SaveResult"] = "Your Brewery was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Brewery could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBreweryService();
            var model = svc.GetBreweryById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBreweryService();

            service.DeleteBrewery(id);

            TempData["SaveResult"] = "Your Brewery was deleted";

            return RedirectToAction("Index");
        }
        private BreweryService CreateBreweryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BreweryService(userId);
            return service;
        }

    }
}