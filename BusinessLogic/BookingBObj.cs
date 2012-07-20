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

          public void setBookingRange(DateTime startDate, int numberOfDays)
          {
               this._fromDate = startDate;
               this._numberOfDays = numberOfDays;
               this._toDate = startDate.AddDays(numberOfDays);
          }

          public void setBookingRange(DateTime startDate, DateTime endDate)
          {
               this._fromDate = startDate;
               this._toDate = endDate;
               this._numberOfDays = (startDate - endDate).Days;
          }

          public Decimal totalCost()
          {
               return _car.dailyRate() * _numberOfDays;
          }

     }
}
