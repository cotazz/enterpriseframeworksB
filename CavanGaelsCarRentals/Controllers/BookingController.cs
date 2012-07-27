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
using System.Web.Security;

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

             var email = "";
             if (User.Identity.IsAuthenticated)
                  email = Membership.GetUser().Email;
             UserObj u = CustomUserService.loadUser(email);
             if (!u.Customer)
             {
                  return RedirectToAction("Login", "Account", new
                  {
                       returnUrl = "/Booking/Create?car_reg=" + car_reg + 
                       "&fromdate=" + fromdate + "&todate=" + todate + "&place=" + place
                  });
             }


            BookingCreateUI showChosenCar = new BookingCreateUI();
            Car car = new Car();
            car.car_reg = car_reg;
            showChosenCar.fromDate = fromdate;
            showChosenCar.toDate = todate;
            showChosenCar.car = car;
            showChosenCar.place = place;


            BookingCreateUI result = logic.ShowChosenCar(showChosenCar);
            return View(result);
        }

        //
        // POST: /Booking/Create

        [HttpPost]
        public ActionResult Create(BookingCreateUI booking)
        {
             var email = "";
             if (User.Identity.IsAuthenticated)
                  email = Membership.GetUser().Email;
             UserObj u = CustomUserService.loadUser(email);
             if (!u.Customer)
                  return RedirectToAction("Login", "Account");

             if (ModelState.IsValid)
             {
                  BookingConfirmUI bookingConfirm = new BookingConfirmUI();
                  bookingConfirm = logic.CreateBooking(booking, u.Id());
                  return RedirectToAction("Confirm", new { booking_id = bookingConfirm.BookingId });
             }

             return View(booking);
        }

        //
        // GET: /Booking/Confirm

        public ActionResult Confirm(int booking_id)
        {
             var email = "";
             if (User.Identity.IsAuthenticated)
                  email = Membership.GetUser().Email;
             UserObj u = CustomUserService.loadUser(email);
             if (!u.Customer)
                  return RedirectToAction("Login", "Account");
             BookingConfirmUI bookingConfirm = new BookingConfirmUI();
             bookingConfirm = logic.ShowBookingConfirm(booking_id, u.Id());
             return View(bookingConfirm);

        }
         

    }
}
