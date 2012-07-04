using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CavanGaelsCarRentals.Models.ui;

namespace CavanGaelsCarRentals.Models
{
     public class Db : DbContext
     {
          public DbSet<BookingUI> BookingUIs { get; set; }

          public DbSet<Car> Cars { get; set; }
     }
}