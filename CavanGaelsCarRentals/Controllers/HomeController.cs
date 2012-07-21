using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models.ui;
using CavanGaelsCarRentals.Logic;

namespace CavanGaelsCarRentals.Controllers
{
    public class HomeController : Controller
    {
        private IServiceLayer logic = new ServiveLayer();
        public ActionResult Index()
        {
            LocationsUI locations = new LocationsUI();
            locations = logic.ListAvailableLocations();
            
            return View(locations);
        }

        public ActionResult CarsAvailable(string fromDate, string location, string toDate)
        {

            return PartialView("_CarsCount" , logic.TotalCarsAvailable(location, fromDate, toDate));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
