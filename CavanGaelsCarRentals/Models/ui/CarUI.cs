using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CavanGaelsCarRentals.Models.ui
{
     public class CarUI
     {
          
          public int id { get; set; }
          public string car_reg { get; set; }
          public MultiSelectList Suppliers { get; set; }

     }
}