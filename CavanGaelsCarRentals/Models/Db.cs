﻿using System;
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

          public Db()
          {
               if (!( this.Database.Exists() ))
               {    // Create a default SQL Express DB
                    this.Database.Create();
               }
          
          }

          public DbSet<Supplier> Suppliers { get; set; }
     }
}