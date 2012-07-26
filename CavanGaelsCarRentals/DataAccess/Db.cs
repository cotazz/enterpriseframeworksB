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
          // public DbSet<BookingUI> BookingUIs { get; set; }

          public DbSet<Car> Cars { get; set; }
          public DbSet<Customer> Customers { get; set; }
          public DbSet<Unavailable> Unavailabilities{ get; set; }
          public DbSet<Booking> Bookings { get; set; }

          public Db()
          {
               var cs = "Server=tcp:ygir540x4r.data" + "base.win" + "dows.net,1433;Database=cavangaels; User ID=ca" +
                    "vangaels12345@ygir540x4r; P" +"ass" + "wor" + "d=What'supdoc" +
                    "?;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";
               this.Database.Connection.ConnectionString = cs;
          }

          public DbSet<Supplier> Suppliers { get; set; }

     }
}