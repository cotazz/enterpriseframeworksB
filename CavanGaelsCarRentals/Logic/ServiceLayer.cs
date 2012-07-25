using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.DataAccess;
using CavanGaelsCarRentals.Models.ui;
using System.Web.Mvc;
using BusinessLogic;

namespace CavanGaelsCarRentals.Logic
{
    public class ServiceLayer : IServiceLayer
    {
         
         private Repository db = new Repository();
        public Models.ui.LocationsUI ListAvailableLocations()
        {

             var locations = db.listAvailableLocations();
             return new LocationsUI
             {
                  locations = new SelectList(locations),
                  fromDate = DateTime.Now.AddDays(5),
                  toDate = DateTime.Now.AddDays(10)
             };
        }

        public Models.ui.LocationCarsCount TotalCarsAvailable(string location, string fromDate, string toDate)
        {
             DateTime from = DateTime.ParseExact(fromDate, "d/M/yyyy", null);
             DateTime to = DateTime.ParseExact(fromDate, "d/M/yyyy", null); 
             var cars = db.listAvailableCars(location, from, to);
             return new LocationCarsCount
             {
                  AvailableCount = cars.Count()
             };
        }

        public Models.ui.BookingUI ListAvailableCars(Models.ui.LocationsUI requestedTimePlace)
        {
             // Request comes in with 3 paramaters:
             DateTime fromDate = requestedTimePlace.fromDate;
             DateTime toDate = requestedTimePlace.toDate;
             string location = requestedTimePlace.location;

             // Load available cars
             var cars = db.listAvailableCars(location, fromDate, toDate);

             // Build result
             

             BookingUI carResults = new BookingUI();
             carResults.amount = cars.Count();
             carResults.Cars = cars.ToList();
             carResults.toDate = toDate;
             carResults.fromDate = fromDate;
             carResults.id = 1;
             carResults.Location = location;
             return carResults;
        }

        public Models.ui.BookingCreateUI ShowChosenCar(BookingCreateUI car)
        {
            

             var result = new BookingCreateUI();
             return result;
        }

        public Models.ui.BookingConfirmUI ShowBookingConfirm(Models.ui.BookingCreateUI booking)
        {
            throw new NotImplementedException();
        }
    }
}