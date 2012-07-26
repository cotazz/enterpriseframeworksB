using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.DataAccess
{
    public class Repository
    {
        private Db db = new Db();

         public List<string> listAvailableLocations()
         {
              var cars = db.Cars.ToList();
              var result = new List<string>();
              foreach (var car in cars)
              {
                   if (result.Contains(car.location))
                        continue;
                   result.Add(car.location);
              }
              return result;
         }

         public IEnumerable<Car> listAvailableCars(string location, DateTime fromDate, DateTime toDate)
         {
              var query = from Car in db.Cars where
                          Car.location.Equals(location)
                          && Car.Unavailablile.All(
                              u => fromDate > u.end_date ||
                                   toDate < u.start_date
                          ) select Car;
              return query.ToList();
         }

         public int getCarIdByReg(string car_reg)
         {
              var serach = from Car in db.Cars
                           where
                                Car.car_reg.Equals(car_reg)
                           select Car;
              var car = serach.FirstOrDefault();
              return car.Id;
         }

         public List<Unavailable> listUnavailabilitiesForCar(int car_id)
         {
              var query = from Unavailable in db.Unavailabilities
                           where
                                Unavailable.CarId.Equals(car_id)
                           select Unavailable;
              return query.ToList();
         }


         public void createNewBooking(int customer_id, int carId, DateTime startDate, DateTime endDate)
         {
              Booking b = new Booking();
              b.CarId = carId;
              b.CustomerId = customer_id;
              b.date = DateTime.Now;
              Unavailable u = new Unavailable();
              u.CarId = carId;
              u.start_date = startDate;
              u.end_date = endDate;
              u.reason_text = "Booking";
              db.Bookings.Add(b);
              db.Unavailabilities.Add(u);
              db.SaveChanges();
         }

         public void createUnavailable(DateTime fromDate, DateTime toDate)
         {
             
         }
    }
}