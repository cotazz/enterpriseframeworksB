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
    public class ServiveLayer : IServiceLayer
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

        public Models.ui.LocationCarsCount TotalCarsAvailable(string location)
        {
            throw new NotImplementedException();
        }

        public Models.ui.BookingUI ListAvailableCars(Models.ui.LocationsUI requestedTimePlace)
        {
             // Request comes in with 3 paramaters:
             DateTime fromDate = requestedTimePlace.fromDate;
             DateTime toDate = requestedTimePlace.toDate;
             string location = requestedTimePlace.locations.SelectedValues.ToString();

             // Load available cars
             var cars = db.listAvailableCars(location, fromDate, toDate);

             // Build result
             

             BookingUI carResults = new BookingUI();
             carResults.amount = cars.Count();
             carResults.Cars = new MultiSelectList(
                  cars,
                  "Id",
                  "car_reg",
                   cars.Select(c => c.Id)
              );
             carResults.toDate = toDate;
             carResults.fromDate = fromDate;
             carResults.id = 1;
             return carResults;
        }

        public Models.ui.BookingCreateUI ShowChosenCar(Models.ui.BookingUI selectedCar)
        {
            throw new NotImplementedException();
        }

        public Models.ui.BookingConfirmUI ShowBookingConfirm(Models.ui.BookingCreateUI booking)
        {
            throw new NotImplementedException();
        }
    }
}