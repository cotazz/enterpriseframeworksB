using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CavanGaelsCarRentals.Models
{
     public class BookingConfirmDTO
     {
          public int BookingId { get; set; }
          public string CarReg { get; set; }
          public string SupplierEmail { get; set; }
          public string CustomerEmail { get; set; }
          public Decimal Cost { get; set; }
          public DateTime fromDate { get; set; }
          public DateTime toDate { get; set; }
          
     }
}