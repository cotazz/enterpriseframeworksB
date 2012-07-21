using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CavanGaelsCarRentals.Models.ui
{
     public class BookingUI
     {
          public int id { get; set; }
          public double amount { get; set; }
          public DateTime fromDate { get; set; }
          public DateTime toDate { get; set; }
          public List<Car> Cars { get; set; }

     }
}