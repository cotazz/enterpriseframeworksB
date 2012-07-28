using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic
{
     public class BookingBObj
     {
          private CarBObj _car = null;
          private SupplierBObj _supplier = null;
          private CustomerBObj _customer = null;
          private DateTime _fromDate = DateTime.Now;
          private DateTime _toDate = DateTime.Now;
          private DateTime _unavailableStart = DateTime.Now;
          private DateTime _unavailableEnd = DateTime.Now;
          private int _numberOfDays = 0;

         
          public BookingBObj(CarBObj car, SupplierBObj supplier)
          {
               this._car = car;
               this._supplier = supplier;
          }

          public static BookingBObj newBooking(CarBObj car)
          {
               return new BookingBObj(car, car.getSupplier());
          }

          public CarBObj getCar()
          {
               return _car;
          }

          public SupplierBObj getSupplier()
          {
               return _supplier;
          }

          /// <summary>
          /// Takes a start date in the future and number of days 
          /// to return date
          /// </summary>
          /// <param name="startDate">DateTime in the future</param>
          /// <param name="numberOfDays">Number of days must be at least 1</param>
          public void setBookingRange(DateTime startDate, int numberOfDays)
          {
              if (startDate < DateTime.Now)
                  throw new ArgumentException();
              else
                   this._fromDate = startDate;

              if (numberOfDays < 1)
                  throw new ArgumentException();
              else
                this._numberOfDays = numberOfDays;

              this._toDate = startDate.AddDays(numberOfDays);
          }

          public void setBookingRange(DateTime startDate, DateTime endDate)
          {

               TimeSpan span = endDate - startDate;
               int numberOfDays = span.Days;
               this.setBookingRange(startDate, numberOfDays);
          }

          public void setCustomer(CustomerBObj c)
          {
              _customer = c;
          }

          public CustomerBObj getCustomer()
          {
              return _customer;
          }

          public DateTime startDate()
          {
              return _fromDate;
          }

          


          public Decimal getTotalCost()
          {
               return _car.dailyRate() * _numberOfDays;
          }
                    

          public bool valid(List<UnavailableDateBObj> calendar)
          {

               if (calendar.All(u => _fromDate > u.toDate || _toDate < u.fromDate))
                    return true;
               else
                    return false;
          }

          public UnavailableDateBObj create()
          {
               return new UnavailableDateBObj { fromDate = _fromDate, toDate = _toDate };
          }

     }
}
