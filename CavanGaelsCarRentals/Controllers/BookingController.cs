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
        public ActionResult Create(string car_reg, string place, int from_year, int from_month, int from_day,
             int to_year, int to_month, int to_day)
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
                       "&from_year=" + from_year + "&from_month=" + from_month + "&from_day=" +
                       from_day + "&to_year=" + to_year + "&to_month=" + to_month +  "&to_day=" +
                       to_day + "&place=" + place
                  });
             }
             var from_string = from_year + "/" + from_month + "/" + from_day;
             DateTime fromdate = DateTime.ParseExact(from_string, "yyyy/M/d", null);
             var to_string = to_year + "/" + to_month + "/" + to_day;
             DateTime todate = DateTime.ParseExact(to_string, "yyyy/M/d", null);


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
                  return RedirectToAction("Login", "Account", new { 
                       returnUrl = "/Booking/Confirm?booking_id=" + booking_id  } );
             BookingConfirmUI bookingConfirm = new BookingConfirmUI();
             bookingConfirm = logic.ShowBookingConfirm(booking_id, u.Id());
             return View(bookingConfirm);

        }
         

    }
}
