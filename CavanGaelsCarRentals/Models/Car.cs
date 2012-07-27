using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Web.Mvc;


namespace CavanGaelsCarRentals.Models
{
     // Rightclick-Add Referemce to System.Xml.Linq
     // Add using System.Data.Linq.Mapping;

     [Table(Name="Cars")]
     public class Car
     {
          public Car() { }
          [Column(IsPrimaryKey = true, IsDbGenerated = true)]
          public int Id { get; set; }
          [Column]
          public string car_reg { get; set; }
          [Column]
          public string location { get; set; }
          [Column]
          public string car_make { get; set; }
          [Column]
          public string car_model { get; set; }
          [Column]
          public int number_of_passengers { get; set; }
          [Column]
          public string luggage_space { get; set; }
          [Column]
          public string image_url { get; set; }
          [Column]
          public decimal cost_per_day { get; set; }
          [Column]
          float gpsmap_x { get; set; }
          [Column]
          float gpsmap_y { get; set; }
          [Column]
          public int SupplierId { get; set; }
          private EntityRef<Supplier> _Supplier = new EntityRef<Supplier>();// new prevents null ref exception

          [Association(Name = "FK_Car_Supplier", Storage = "_Supplier", ThisKey = "SupplierId", OtherKey = "Id", IsForeignKey = true)]
          public Supplier Supplier
          {
               get
               {
                    return _Supplier.Entity;
               }
               set
               {
                    _Supplier.Entity = value;
               }
          }
          private EntitySet<Booking> _Bookings = new EntitySet<Booking>();// new prevents null ref exception
          [Association(Name="Car_Bookings", Storage = "_Bookings", ThisKey="Id", OtherKey="CarId")]
          public EntitySet<Booking> Bookings
          {
               get { return this._Bookings; }
               set { this._Bookings.Assign(value); }
          }

          private EntitySet<Unavailable> _Unavailable = new EntitySet<Unavailable>();// new prevents null ref exception
          [Association(Name="Car_Unavailabilities", Storage = "_Unavailable", ThisKey="Id", OtherKey = "CarId")]
          public EntitySet<Unavailable> Unavailablile
          {
               get { return this._Unavailable; }
               set { this._Unavailable.Assign(value); }
          }
     }
}
