using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models;
using CavanGaelsCarRentals.Models.ui;
using System.Web.Caching;
using CavanGaelsCarRentals.Logic;

namespace CavanGaelsCarRentals.Controllers
{
    public class BookingController : Controller
    {
        private IServiceLayer logic = new ServiceLayer();
        

        //
        // POST: /Booking/
         [HttpPost]
        public ActionResult Index(LocationsUI requestedTimePlace)
        {
             BookingUI carList = new BookingUI();
             carList = logic.ListAvailableCars(requestedTimePlace);
             return View(carList);

        }

         //
         // GET: /Booking/Create
        public ActionResult Create(string car_reg, DateTime fromdate, DateTime todate, string place)
        {
       //      List<Car> cars = db.Cars.ToList();
         //    BookingUI model = new BookingUI
         //    {

         //           Cars = new MultiSelectList(
         ////                   cars,
         //                   "Id",
         //                   "car_reg",
         //                   cars.Select(c => c.Id)
         //                   )

         //    };
         //    return View(model);
            BookingCreateUI showChosenCar = new BookingCreateUI();
            showChosenCar.fromDate = fromdate;
            showChosenCar.toDate = todate;
            showChosenCar.car.car_reg = car_reg;
              showChosenCar.location = place;
            showChosenCar = logic.ShowChosenCar(showChosenCar);
            return View(showChosenCar);
        }

        //
        // POST: /Booking/Create

        [HttpPost]
        public ActionResult View1(BookingCreateUI booking)
        {
            // Booking booking = new Booking();
            // booking.booking_count = 0;
            //// Car car = db.Cars.Find(collection.Cars);
            //// booking.Car = car;
            // booking.date = collection.fromDate;
            // var s = db.Suppliers.FirstOrDefault();
            // var cars = s.Cars;
            // booking.Customer = db.Customers.FirstOrDefault();
            // booking.email = "test@example.com";
            // // temp.Insert("1", booking);
            // db.Bookings.Add(booking);
            // db.SaveChanges();     
            // return RedirectToAction("CreateStep2", booking);
            BookingConfirmUI bookingConfirm = new BookingConfirmUI();
            bookingConfirm = logic.ShowBookingConfirm(booking);
            return View(bookingConfirm);
        }

         //
         // GET: /Booking/CreateStep2
        public ActionResult CreateStep2(Booking Booking)
        {
             

             
               //return View(logic.SBookingConfirm.ShowConfirmUI(Booking));
             return View();
        }

    }
}
