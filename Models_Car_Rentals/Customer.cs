using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace Models_Car_Rentals
{
     [Table(Name="Customers")]
     class Customer
     {
          [Column(IsPrimaryKey = true)]
          public string customer_id;
          [Column]
          public string email;
          [Column]
          public int booking_count;
          private EntitySet<Booking> _Bookings;
          [Association(Storage = "_Cars", OtherKey = "CustomerID")]
          public EntitySet<Booking> Cars
          {
               get { return this._Bookings; }
               set { this._Bookings.Assign(value); }
          }
     }
}
