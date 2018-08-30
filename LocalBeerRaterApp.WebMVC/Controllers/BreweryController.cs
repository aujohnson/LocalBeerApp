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
            if (ModelState.IsValid)
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

        private BreweryService CreateBreweryService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BreweryService(userId);
            return service;
        }

    }
}