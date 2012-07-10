using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models;
using CavanGaelsCarRentals.Models.ui;
using System.Web.Caching;

namespace CavanGaelsCarRentals.Controllers
{
    public class BookingController : Controller
    {
         private Db db = new Db();
         private Cache temp = new Cache();
        //
        // GET: /Booking/

        public ActionResult Index()
        {
            
            return View(db.Bookings.ToList());
             
        }


         //
         // GET: /Booking/Create
        public ActionResult Create()
        {
             List<Car> cars = db.Cars.ToList();
             BookingUI model = new BookingUI
             {

                    Cars = new MultiSelectList(
                            cars,
                            "Id",
                            "car_reg",
                            cars.Select(c => c.Id)
                            )

             };
             return View(model);
        }

        //
        // POST: /Booking/Create

        [HttpPost]
        public ActionResult Create(BookingResponse collection)
        {
             Booking booking = new Booking();
             booking.booking_count = 0;
             Car car = db.Cars.Find(collection.Cars);
             booking.Car = car;
             booking.date = collection.fromDate;
             var s = db.Suppliers.FirstOrDefault();
             var cars = s.Cars;
             var bookings = s.Bookings;
             booking.Customer = db.Customers.FirstOrDefault();
             booking.email = "test@example.com";
             // temp.Insert("1", booking);
             db.Bookings.Add(booking);
             db.SaveChanges();     
             return RedirectToAction("CreateStep2", booking);
         
        }

         //
         // GET: /Booking/CreateStep2
        public ActionResult CreateStep2(Booking b)
        {
             // This step presents Customer with details of their booking
             
             //try
             //{
                  // Booking booking = (Booking)temp.Get(Customer_id);
                  return View(b);
             //}
             //catch
             //{
             //     return RedirectToAction("Index");
             //}
        }

    }
}
