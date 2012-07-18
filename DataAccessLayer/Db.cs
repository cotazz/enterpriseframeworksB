﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Web;

namespace DataAccessLayer
{
     public class Db : DbContext
     {
          // public DbSet<BookingUI> BookingUIs { get; set; }

          public DbSet<Car> Cars { get; set; }
          public DbSet<Customer> Customers { get; set; }
          public DbSet<Unavailable> Unavailabilities { get; set; }
          public DbSet<Booking> Bookings { get; set; }

          public Db()
          {
               if (!(this.Database.Exists()))
               {    // Create a default SQL Express DB
                    this.Database.Create();
               }

          }

          public DbSet<Supplier> Suppliers { get; set; }
     }
}
