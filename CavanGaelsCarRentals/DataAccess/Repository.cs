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
         
         public int createNewBooking(int customer_id, int carId, DateTime startDate, DateTime endDate)
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
              return b.Id;
         }

         public BookingConfirmDTO getBooking(int bookingId, int user)
         {
              var booking = db.Bookings.Where(b => b.Id.Equals(bookingId) && b.CustomerId.Equals(user)).FirstOrDefault();
              if (booking != null && booking.Id > 0)
              {
                   var car = db.Cars.First(c => c.Id.Equals(booking.CarId));
                   var supplier = db.Suppliers.First(s => s.Id.Equals(car.SupplierId));
                   var unavailable = db.Unavailabilities.First(u => u.Id.Equals(booking.UnavailableId);
                   return new BookingConfirmDTO
                   {
                        BookingId = booking.Id,
                        CarReg = car.car_reg,
                        SupplierEmail = supplier.email,
                        CustomerEmail = booking.email,
                        Cost = booking.Car.cost_per_day,
                        fromDate = unavailable.start_date,
                        toDate = unavailable.end_date
                   };
              }
              return null;
         }


    }
}