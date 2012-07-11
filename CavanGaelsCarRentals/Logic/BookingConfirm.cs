using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.Models;
using CavanGaelsCarRentals.Models.ui;

namespace CavanGaelsCarRentals.Logic
{
     public class BookingConfirm
     {
          public static BookingConfirmUI ShowConfirmUI(Booking Booking)
          {
               Db db = new Db();
               var BookingResult = (from bookng in db.Bookings
                                    where bookng.Id.Equals(Booking.Id)
                                    select new BookingConfirmUI
                                    {
                                         BookingId = bookng.Id,
                                         CarReg = bookng.Car.car_reg,
                                         CostPerDay = bookng.Car.cost_per_day,
                                         CustomerEmail = bookng.Customer.email,
                                         SupplierEmail = bookng.Car.Supplier.email
                                    }).FirstOrDefault();
               return BookingResult;
          }
     }
}