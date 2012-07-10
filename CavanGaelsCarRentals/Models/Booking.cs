using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Web.Caching;


namespace CavanGaelsCarRentals.Models
{
     // Rightclick-Add Referemce to System.Xml.Linq
     // Add using System.Data.Linq.Mapping; and System.Data.Linq
     // Id
     // email
     // booking_count    int
     // date             DateTime
     // Customer         int       Customer_id
     // Supplier         int       Supplier_id   (auto set from car)
     // Car              int       Car_id
     [Table(Name="Bookings")]
     public class Booking
     {
          [Column(IsPrimaryKey=true, IsDbGenerated=true)]
          public int Id {get; set;}
          [Column]
          public string email {get; set;}
          [Column]
          public int booking_count {get; set;}
          public DateTime date {get; set;}
          [Column]
          public int CustomerId {get;set;}
          private EntityRef<Customer> _Customer = new EntityRef<Customer>();// new prevents null ref exception
          [Association( Name="FK_Booking_Customer", Storage = "_Customer", ThisKey="CustomerId" , OtherKey="Id" , IsForeignKey=true)]
          public Customer Customer
          {
               get
               {
                    return this._Customer.Entity;
               }
               set
               {
                    this._Customer.Entity = value;
               }
          }

          [Column]
          public int SupplierId { get; set; }

          private EntityRef<Supplier> _Supplier = new EntityRef<Supplier>();
          [Association(Name = "FK_Booking_Supplier", Storage = "_Supplier", ThisKey = "SupplierId", OtherKey = "Id")]
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

          [Column]
          public int CarId { get; set; }
          private EntityRef<Car> _Car = new EntityRef<Car>(); // new prevents null ref exception
          [Association(Name="FK_Booking_Car", Storage = "_Car", ThisKey = "CarId", OtherKey = "Id", IsForeignKey = true)]
          public Car Car
          {
               get
               {
                    return _Car.Entity;
               }
               set
               {
                   
                    _Car.Entity = value;
                         
                    
               }
          }
     }
}
