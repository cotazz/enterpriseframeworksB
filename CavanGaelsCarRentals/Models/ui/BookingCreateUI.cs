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
          public Decimal amount { get; set; }
          public string location { get; set; }
          public DateTime fromDate { get; set; }
          public DateTime toDate { get; set; }
     }
}