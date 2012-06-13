using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace Models_Car_Rentals
{
     // Rightclick-"Add Referemce" for System.Xml.Linq
     // Add using System.Data.Linq.Mapping; and System.Data.Linq

     [Table(Name="Suppliers")]
     class Supplier
     {
          [Column(IsPrimaryKey = true)]
          public string supplier_id;
          [Column]
          public string email;
          [Column]
          public string location;
          [Column]
          float gpsmap_x;
          [Column]
          float gpsmap_y;
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
