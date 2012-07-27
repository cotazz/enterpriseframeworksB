using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.DataAccess;
using CavanGaelsCarRentals.Models.ui;
using System.Web.Mvc;
using BusinessLogic;
using CavanGaelsCarRentals.Models;

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
             DateTime from = DateTime.ParseExact(fromDate, "yyyy/M/d", null);
             DateTime to = DateTime.ParseExact(toDate, "yyyy/M/d", null); 
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

             foreach (var car in cars)
             {
                  CarObj c = new CarObj();
                  c.Car = car;
                  TimeSpan span = toDate - fromDate;
                  int numberOfDays = span.Days;
                  c.TotalCost = car.cost_per_day * numberOfDays;
                  carResults.Cars.Add(c);
             }
             carResults.toDate = toDate;
             carResults.fromDate = fromDate;
             carResults.id = 1;
             carResults.Location = location;
             return carResults;
        }

        public Models.ui.BookingCreateUI ShowChosenCar(BookingCreateUI car)
        {
            
             var supplierObj = new SupplierBObj();
             var carObj = new CarBObj(supplierObj);
             var booking = new BookingBObj(carObj, supplierObj);

             var startDate = car.fromDate;
             var endDate = car.toDate;
             var car_reg = car.car.car_reg;

             var carId = db.getCarIdByReg(car_reg);


             carObj.setId(carId);
             
             booking.setBookingRange(startDate, endDate);

             var dbUnavailabilities = db.listUnavailabilitiesForCar(carId);
             var unavailabilities = new List<UnavailableDateBObj>();

             foreach (var u in dbUnavailabilities)
             {
                  var unavailable = new UnavailableDateBObj{ fromDate = u.start_date, toDate = u.end_date };
                  unavailabilities.Add(unavailable);
             }


             car.valid = booking.valid(unavailabilities);
             car.amount = booking.getTotalCost();
             return car;
                  
        }

        public Models.ui.BookingConfirmUI CreateBooking(Models.ui.BookingCreateUI car, int userId)
        {
             var result = new BookingConfirmUI();

             var supplierObj = new SupplierBObj();
             var carObj = new CarBObj(supplierObj);
             var booking = new BookingBObj(carObj, supplierObj);

             var startDate = car.fromDate;
             var endDate = car.toDate;
             var car_reg = car.car_reg;

             var carId = db.getCarIdByReg(car_reg);


             carObj.setId(carId);

             booking.setBookingRange(startDate, endDate);

             var dbUnavailabilities = db.listUnavailabilitiesForCar(carId);
             var unavailabilities = new List<UnavailableDateBObj>();

             foreach (var u in dbUnavailabilities)
             {
                  var unavailable = new UnavailableDateBObj { fromDate = u.start_date, toDate = u.end_date };
                  unavailabilities.Add(unavailable);
             }


             car.valid = booking.valid(unavailabilities);
             if (car.valid)
             {
                  car.amount = booking.getTotalCost();
                  UnavailableDateBObj date = booking.create();

                  var customer_id = userId;
                  result.BookingId = db.createNewBooking(customer_id, carId, startDate, endDate);

             }
             result.CarReg = car_reg;
             result.Cost = booking.getTotalCost();
             return result;
        }

        public Models.ui.BookingConfirmUI ShowBookingConfirm(int bookingId, int userId)
        {
             var result = new BookingConfirmUI();
             result.BookingId = bookingId;
             BookingConfirmDTO b = db.getBooking(bookingId, userId);
             if (b != null)
             {
                  result.CarReg = b.CarReg;
                  TimeSpan span = b.toDate - b.fromDate;
                  int numberOfDays = span.Days;
                  result.Cost = b.Cost * numberOfDays;
                  result.CustomerEmail = b.CustomerEmail;
                  result.SupplierEmail = b.SupplierEmail;
                  result.fromDate = b.fromDate;
                  result.toDate = b.toDate;
             }

             return result;
        }


    }
}