using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Models_Car_Rentals
{
     class Program
     {
          // Supplier
          // Customer
          // Car
          // Booking
          // Unavailable
          static void Main(string[] args)
          {
               // Example: won't work without database entries.
               Car opel = new Car();
               Supplier s= opel.Supplier;
               EntitySet<Car> suppliercars = s.Cars;
               EntitySet<Booking> supplierbookings = s.Bookings;
               DateTime IWantABookinG = DateTime.Now.AddDays(10);
               int IWantForDays = 3;
               DateTime startdate = IWantABookinG;
               DateTime enddate = IWantABookinG.AddDays(IWantForDays);
               int car_count = 0;
               bool available = true;
               // This is a rough idea of how to look up available cars
               Car[] available_cars = new Car[10];
               foreach (Car c in suppliercars)
               {
                    EntitySet<Unavailable> notavailabletimes = c.Unavailablile;
                    // Each car has many unavailable periods that are checked
                    // Down the line instead of retrieve all unavailable times,
                    // we write sql query to match exact dates (more efficient)
                    foreach (Unavailable x in notavailabletimes)
                    {    // Car unavailable if dates match these rules:

                         if (enddate > x.start_date && enddate < x.end_date)
                         { // If the cars enddate within unavailability
                              available = false;
                              break;
                         }
                         if (startdate > x.start_date && startdate < x.end_date)
                         { // If the cars startdate withing unavailability
                              available = false;
                              break;
                         }

                         if (x.end_date > startdate && x.end_date < enddate)
                         { // If the unavailability enddate within requested period
                              available = false;
                              break;
                         }
                         if (x.start_date > startdate && x.end_date < enddate)
                         { // If the unavailability startdate witin requested period
                              available = false;
                              break;
                         }

                    }
                    if (available)
                         available_cars[car_count++] = c; // add c into cars array, then add 1 to car_count
                    else // available false
                         available = true; // reset available for next car
               }

          }
     }
}
