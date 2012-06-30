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

     [Table(Name = "Unavailabilities")]
     class Unavailable
     {
          [Column(IsPrimaryKey = true)]
          public string Unavailability_id;
          [Column]
          public string reason_text;
          [Column]
          public DateTime start_date;
          public DateTime end_date;
          private EntityRef<Car> _Car;
          [Association(Name = "FK_Unavailabilities_Cars", Storage = "_Car", ThisKey = "CarID", IsForeignKey = true)]
          public Car Car
          {
               get
               {
                    return this._Car.Entity;
               }
               set
               {
                    Car previousValue = this._Car.Entity;
                    if (((previousValue != value)
                                   || (this._Car.HasLoadedOrAssignedValue == false)))
                    {
                         // this.SendPropertyChanging();
                         //if ((previousValue != null))
                         //{
                         //     this._Customer.Entity = null;
                         //     previousValue.Bookings.Remove(this);
                         //}
                         this._Car.Entity = value;
                         //if ((value != null))
                         //{
                         //     value.Bookings.Add(this);
                         //     this._CustomerID = value.CustomerID;
                         //}
                         //else
                         //{
                         //     this._CustomerID = default(string);
                         //}
                         // this.SendPropertyChanged("Customer");
                    }
               }
          }
     }
}
