using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CavanGaelsCarRentals.Models.ui
{
     public class BookingUI
     {
          private static Db db = new Db();
          public int id { get; set; }
          public double amount { get; set; }
          public DateTime fromDate { get; set; }
          public DateTime toDate { get; set; }
          public MultiSelectList Cars { get; set; }

          public static Booking ProcessUIForm(FormCollection c)
          {
               Booking b = new Booking();
               foreach (var key in c.AllKeys)
               {
                    var v = c[key.ToString()];
                    switch (key.ToString())
                    {
                         case "Car":
                              b.Car = db.Cars.Find(Convert.ToInt32(v));
                              break;
                         case "fromDate":
                              b.date = Convert.ToDateTime(v);
                              break;
                    }
               }
               
               return b;
          }

     }
}