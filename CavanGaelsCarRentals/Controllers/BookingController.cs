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
        private IServiceLayer logic = new ServiveLayer();
        //
        // GET: /Booking/

        public ActionResult Index(LocationsUI requestedTimePlace)
        {
            BookingUI carList = new BookingUI();
            carList = logic.ListAvailableCars(requestedTimePlace);
            return View(carList);
             
        }


         //
         // GET: /Booking/Create
        public ActionResult Create(BookingUI selectedCar)
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
            showChosenCar = logic.ShowChosenCar(selectedCar);
            return View(showChosenCar);
        }

        //
        // POST: /Booking/Create

        [HttpPost]
        public ActionResult Create(BookingCreateUI booking)
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
             

             
               return View(BookingConfirm.ShowConfirmUI(Booking));
          
        }

    }
}
