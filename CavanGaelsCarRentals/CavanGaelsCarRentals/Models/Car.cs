using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace Models_Car_Rentals
{
     // Rightclick-Add Referemce to System.Xml.Linq
     // Add using System.Data.Linq.Mapping;

     [Table(Name="Cars")]
     class Car
     {
          [Column(IsPrimaryKey = true)]
          public string car_id;
          [Column]
          public string car_reg;
          [Column]
          public string location;
          [Column]
          public decimal cost_per_day;
          [Column]
          float gpsmap_x;
          [Column]
          float gpsmap_y;
          private EntityRef<Supplier> _Supplier;
          [Association(Name = "FK_Cars_Suppliers", Storage = "_Supplier", ThisKey = "SupplierID", IsForeignKey = true)]
          public Supplier Supplier
          {
               get
               {
                    return this._Supplier.Entity;
               }
               set
               {
                    Supplier previousValue = this._Supplier.Entity;
                    if (((previousValue != value)
                                   || (this._Supplier.HasLoadedOrAssignedValue == false)))
                    {
                         this._Supplier.Entity = value;

                    }
               }
          }
          private EntitySet<Booking> _Bookings;
          [Association(Storage = "_Bookings", OtherKey = "CustomerID")]
          public EntitySet<Booking> Bookings
          {
               get { return this._Bookings; }
               set { this._Bookings.Assign(value); }
          }
          private EntitySet<Unavailable> _Unavailable;
          [Association(Storage = "_Unavailabile", OtherKey = "Unavailability_id")]
          public EntitySet<Unavailable> Unavailablile
          {
               get { return this._Unavailable; }
               set { this._Unavailable.Assign(value); }
          }
     }
}
