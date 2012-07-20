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
    }
}