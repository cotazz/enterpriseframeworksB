using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace CavanGaelsCarRentals.Models
{
     [Table(Name="Customers")]
     public class Customer
     {
          [Column(IsPrimaryKey = true, IsDbGenerated = true)]
          public int Id { get; set; }
          [Column]
          public string email { get; set; }
          [Column]
          public int booking_count { get; set; }

          private EntitySet<Booking> _Bookings = new EntitySet<Booking>(); // new prevents null ref exception
          [Association(Name="Customer_Bookings",Storage = "_Bookings", ThisKey="Id", OtherKey = "CustomerId")]
          public EntitySet<Booking> Bookings
          {
               get { return this._Bookings; }
               set { this._Bookings.Assign( value); }
          }
     }
}
