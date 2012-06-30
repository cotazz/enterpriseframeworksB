using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;


namespace Models_Car_Rentals
{
     // Rightclick-Add Referemce to System.Xml.Linq
     // Add using System.Data.Linq.Mapping; and System.Data.Linq

     [Table(Name="Bookings")]
     class Booking
     {
          [Column(IsPrimaryKey = true)]
          public string booking_id;
          [Column]
          public string email;
          [Column]
          public int booking_count;
          public DateTime date;
          private EntityRef<Customer> _Customer;
          [Association(Name = "FK_Bookings_Customers", Storage = "_Customer", ThisKey = "CustomerID", IsForeignKey = true)]
          public Customer Customer
          {
               get
               {
                    return this._Customer.Entity;
               }
               set
               {
                    Customer previousValue = this._Customer.Entity;
                    if (((previousValue != value)
                                   || (this._Customer.HasLoadedOrAssignedValue == false)))
                    {
                         // this.SendPropertyChanging();
                         //if ((previousValue != null))
                         //{
                         //     this._Customer.Entity = null;
                         //     previousValue.Bookings.Remove(this);
                         //}
                         this._Customer.Entity = value;
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
          private EntityRef<Supplier> _Supplier;
          [Association(Name = "FK_Bookings_Customers", Storage = "_Supplier", ThisKey = "SupplierID", IsForeignKey = true)]
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
          private EntityRef<Car> _Car;
          [Association(Name = "FK_Bookings_Customers", Storage = "_Car", ThisKey = "CarID", IsForeignKey = true)]
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
                         this._Car.Entity = value;

                    }
               }
          }
     }
}
