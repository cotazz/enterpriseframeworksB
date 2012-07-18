using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace CavanGaelsCarRentals.Models
{
     // Rightclick-Add Referemce to System.Xml.Linq
     // Add using System.Data.Linq.Mapping;

     [Table(Name = "Unavailabilities")]
     public class Unavailable
     {
          [Column(IsPrimaryKey = true, IsDbGenerated = true)]
          public int Id { get; set; }
          [Column]
          public string reason_text { get; set; }
          [Column]
          public DateTime start_date { get; set; }
          public DateTime end_date { get; set; }

          [Column]
          public int CarId { get; set; }
          private EntityRef<Car> _Car = new EntityRef<Car>(); // new prevents null ref exception
          [Association(Name = "FK_Unavailable_Car", Storage = "_Car", OtherKey="Id", ThisKey = "CarId", IsForeignKey = true)]
          public Car Car
          {
               get
               {
                    return this._Car.Entity;
               }
               set
               {
                    this._Car.Entity = value;
               }
          }


          private EntityRef<Booking> _Booking = new EntityRef<Booking>();// new prevents null ref exception
          [Association(Name = "Unavailable_Booking", Storage = "_Booking", ThisKey = "Id", OtherKey = "Unavailability_Id")]
          public EntityRef<Booking> Booking
          {
               get { return this._Booking; }
               set { this._Booking = value; }
          }
     }
}
