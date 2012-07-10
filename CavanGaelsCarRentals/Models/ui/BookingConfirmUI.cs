using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.Mvc;

namespace CavanGaelsCarRentals.Models.ui
{
     public class BookingConfirmUI
     {
          public string CarReg {get;set;}
          public string SupplierEmail { get; set; }
          public string CustomerEmail { get; set; }
          public int BookingId { get; set; }
          public Decimal CostPerDay { get; set; }
     }
}