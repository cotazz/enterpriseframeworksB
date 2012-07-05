using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.Controllers
{
    public class BookingController : Controller
    {
         private Db db = new Db();
        //
        // GET: /Booking/

        public ActionResult Index()
        {
             if (db.Database.Exists())
             {
             }
             else
             {
                  db.Database.Create();
             }
            return View(db.BookingUIs.ToList());
             
        }

    }
}
