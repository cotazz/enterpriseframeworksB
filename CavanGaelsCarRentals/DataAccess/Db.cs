using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CavanGaelsCarRentals.Models.ui;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.DataAccess
{
     public class Db : DbContext
     {
          public DbSet<Car> Cars { get; set; }
          public DbSet<Customer> Customers { get; set; }
          public DbSet<Unavailable> Unavailabilities{ get; set; }
          public DbSet<Booking> Bookings { get; set; }
          public DbSet<Supplier> Suppliers { get; set; }
          public Db()
               : base ("name=DefaultConnection")
          {         
          }

     }
}