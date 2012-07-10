using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CavanGaelsCarRentals.Models.ui
{
     public class BookingResponse
     {
          public int Cars { get; set; }
          public int amount { get; set; }
          public DateTime fromDate { get; set; }
          public DateTime toDate { get; set; }
     }
}