using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CavanGaelsCarRentals.Models.ui
{
     public class BookingUI
     {
          public int id { get; set; }
          public double amount { get; set; }
          public string car_reg { get; set; }
          public string toCurrency { get; set; }
     }
}