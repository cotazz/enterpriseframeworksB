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
             booking.Customer = db.Customers.FirstOrDefault();
             booking.email = "test@example.com";
             // temp.Insert("1", booking);
             db.Bookings.Add(booking);
             db.SaveChanges();     
             return RedirectToAction("CreateStep2", booking);
         
        }

         //
         // GET: /Booking/CreateStep2
        public ActionResult CreateStep2(Booking Booking)
        {
             BookingConfirmUI result_attempt1 = new BookingConfirmUI();
             DateTime start = DateTime.Now;
             var result_attempt2 = (from bookng in db.Bookings
                                   where bookng.Id.Equals(Booking.Id)
                                   select new BookingConfirmUI
                                   {
                                        BookingId = bookng.Id,
                                        CarReg = bookng.Car.car_reg,
                                        CostPerDay = bookng.Car.cost_per_day,
                                        CustomerEmail = bookng.Customer.email,
                                        SupplierEmail = bookng.Car.Supplier.email
                                   }).FirstOrDefault();
             DateTime intermediate = DateTime.Now;
             var query = from booking in db.Bookings.Include("Car").Include("Customer")
                         where booking.Id.Equals(Booking.Id)
                         select booking;
             Booking b = query.FirstOrDefault();
             DateTime finished = DateTime.Now;
             result_attempt1.CarReg = b.Car.car_reg;
             var query1 = from supplier in db.Suppliers
                        where supplier.Id.Equals(b.Car.SupplierId)
                        select supplier;
             Supplier s = query1.FirstOrDefault();
             result_attempt1.SupplierEmail = s.email;
             var query1_profile = intermediate - start;
             var query2_profile = finished - intermediate;
             String profiling_info = "Query 1 : " + Convert.ToString(query1_profile)
                                    + "\nQuery 2: " + Convert.ToString(query2_profile);
             result_attempt1.CustomerEmail = profiling_info;
             result_attempt1.CostPerDay = b.Car.cost_per_day;
               return View(result_attempt1);
          
        }

    }
}
