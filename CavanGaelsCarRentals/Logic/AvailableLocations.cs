using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.Models.ui;
using CavanGaelsCarRentals.Models;
using System.Web.Mvc;

namespace CavanGaelsCarRentals.Logic
{
    public class AvailableLocations
    {
        public static LocationsUI listLocations()
        {
            Db db = new Db();
            var cars = db.Cars.ToList();
            var locations = new List<string>();
            foreach (var car in cars)
            {
                if (locations.Contains(car.location))
                {
                    continue;

                }
                locations.Add(car.location);

            }
            var result = new LocationsUI();
            result.locations = new MultiSelectList(locations);
            return result;
        }

        public static LocationCarsCount TotalCarsAvailable(string location)
        {
            Db db = new Db();

            var cars = db.Cars.ToList();
            var availablecars = new List<Car>();
            foreach (var car in cars)
            {
                if (location.Equals(car.location))
                {
                    //if car.available  Brian to create this

                   
                    availablecars.Add(car);
                }

            }

            var result = new LocationCarsCount();
            result.AvailableCount = availablecars.Count();
            return result;




        }

    }


}