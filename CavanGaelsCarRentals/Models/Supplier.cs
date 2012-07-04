using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace CavanGaelsCarRentals.Models
{
     // Rightclick-"Add Referemce" for System.Xml.Linq
     // Add using System.Data.Linq.Mapping; and System.Data.Linq

     [Table(Name="Suppliers")]
     public class Supplier
     {
          [Column(IsPrimaryKey = true)]
          public int Id { get; set; }
          [Column]
          public string email { get; set; }
          [Column]
          public string location { get; set; }
          [Column]
          float gpsmap_x { get; set; }
          [Column]
          float gpsmap_y { get; set; }
          private EntitySet<Car> _Cars;
          [Association(Storage = "_Cars", OtherKey = "CustomerID")]
          public EntitySet<Car> Cars
          {
               get { return this._Cars; }
               set { this._Cars.Assign(value); }
          }
          private EntitySet<Booking> _Bookings;
          [Association(Storage = "_Bookings", OtherKey = "CustomerID")]
          public EntitySet<Booking> Bookings
          {
               get { return this._Bookings; }
               set { this._Bookings.Assign(value); }
          }
     }
}
