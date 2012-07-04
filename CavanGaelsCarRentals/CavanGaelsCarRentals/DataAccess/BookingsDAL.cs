using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.DataAccess
{
     public class BookingsDAL
     {
          public Booking findBooking(int _id)
          {
               return null;
          }
          public Booking newBooking(DateTime startDate, DateTime endDate)
          {
               return new Booking();
          }
          public Booking deleteBooking(int _id)
          {
               return null;
          }

     }
}