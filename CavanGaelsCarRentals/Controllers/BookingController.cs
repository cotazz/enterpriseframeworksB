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
        // POST: /Booking/Create1

        [HttpPost]
        public ActionResult Create1(BookingCreateUI booking)
        {
            BookingConfirmUI bookingConfirm = new BookingConfirmUI();
            bookingConfirm = logic.ShowBookingConfirm(booking);
            return View(bookingConfirm);
        }

         

    }
}
