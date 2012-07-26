using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CavanGaelsCarRentals.Models.ui
{
     public class BookingCreateUI
     {
          public Car car { get; set; }
          public string car_reg { get; set; }
          public Decimal amount { get; set; }
          public string place { get; set; }
          public DateTime fromDate { get; set; }
          public DateTime toDate { get; set; }
          public string creditcard { get; set; }
          public int expiryMonth { get; set; }
          public int expiryDay { get; set; }
          public bool valid { get; set; }
     }
}