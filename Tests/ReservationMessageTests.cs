using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;


/// When creating a booking for the system
///  - must include a start date
///  - start date must be in the future
///  - must include a end date
///  - end must be later than start date
///  

namespace Tests
{
     public class BookingCreator
     {
          private DateTime _start_date;
          private DateTime _end_date;

          public BookingCreator(DateTime start_date, DateTime end_date)
          {
               if (start_date < DateTime.Now)
               {
                    throw new ArgumentException();
               }
               this._start_date = start_date;

               if (end_date < start_date)
               {
                    throw new ArgumentException();
               }
               this._end_date = end_date;
          }
          
          public DateTime StartDate
          {
               get{
                    return _start_date;
               }
               set{
                    _start_date = value;
               }
          }

          public DateTime EndDate
          {
               get
               {
                    return _end_date;
               }
               set
               {
                    _end_date = value;
               }
          }
     }
          
      [TestClass]
     public class when_create_booking_for_reservation_system
     {
          [TestMethod]
          public void it_must_includ_a_start_date()
          {
              // Arrange
               DateTime start_date = new DateTime(2012, 10, 1);
               DateTime end_date = new DateTime(2012, 11, 1);
               // Act
               var booking_message = new BookingCreator(start_date, end_date);

               // Assert
               Assert.AreEqual(booking_message.StartDate, start_date);
          }

          [TestMethod]
           [ExpectedException(typeof(ArgumentException))]
          public void start_date_must_be_in_future()
          {
               // Arrange
               DateTime start_date = new DateTime(2012, 1, 1);
               DateTime end_date = new DateTime(2012, 1, 1);
               // Act
               var booking_message = new BookingCreator(start_date, end_date);

               // Assert
               Assert.Fail("Message Constructor should have thrown an exception");
          }

          [TestMethod]
          public void it_must_include_an_end_date()
          {
               // Arrange
               DateTime start_date = new DateTime(2012, 10, 1);
               DateTime end_date = new DateTime(2012, 11, 1);

               // Act
               var booking_message = new BookingCreator(start_date, end_date);

               // Assert
               Assert.AreEqual(booking_message.EndDate,  end_date);
          }


          [TestMethod]
          [ExpectedException(typeof(ArgumentException))]
          public void end_date_must_be_later_than_start_date()
          {
               // Arrange
               DateTime start_date = new DateTime(2012, 10, 1);
               DateTime end_date = new DateTime(2012, 7, 1);

               // Act
               var booking_message = new BookingCreator(start_date, end_date);

               // Assert
               Assert.Fail("Message Constructor should have thrown an exception");
          }
     }
}
