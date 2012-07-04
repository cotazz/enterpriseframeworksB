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
          [Column(IsPrimaryKey = true)]
          public int Id { get; set; }
          [Column]
          public string email { get; set; }
          [Column]
          public int booking_count { get; set; }
          private EntitySet<Booking> _Bookings;
          [Association(Storage = "_Cars", OtherKey = "CustomerID")]
          public EntitySet<Booking> Cars
          {
               get { return this._Bookings; }
               set { this._Bookings.Assign(value); }
          }
     }
}
