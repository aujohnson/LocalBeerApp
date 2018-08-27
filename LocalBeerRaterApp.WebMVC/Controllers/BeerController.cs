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
    public class BeerController : Controller
    {
        // GET: Beer
        public ActionResult Index()
        {
            BeerService service = CreateBeerService();
            var model = service.GetBeers();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BeerCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var service = CreateBeerService();

            if (service.CreateBeer(model))
            {
                TempData["SaveResult"] = "Your beer was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Beer could not be created."); if (ModelState.IsValid)
            {

            }
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateBeerService();
            var model = svc.GetBeerById(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateBeerService();
            var detail = service.GetBeerById(id);
            var model =
                new BeerEdit
                {
                    BeerId = detail.BeerId,
                    BeerName = detail.BeerName,
                    BeerType = detail.BeerType
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BeerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BeerId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateBeerService();

            if (service.UpdateBeer(model))
            {
                TempData["SaveResult"] = "Your beer was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your beer could not be updated.");
            return View(model);
        }
        private BeerService CreateBeerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BeerService(userId);
            return service;
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBeerService();
            var model = svc.GetBeerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBeerService();

            service.DeleteNote(id);

            TempData["SaveResult"] = "Your beer was deleted";

            return RedirectToAction("Index");
        }

    }
    
}

