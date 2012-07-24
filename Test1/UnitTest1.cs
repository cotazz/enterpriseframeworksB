using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic;


  /// When creating a booking for car reservation system
  /// - Booking must be in future,
  /// - Booking end date must be after before date
  /// - Booking must have car_id, customer_id
  /// - Booking should calculate total cost (daily rate * number of days)
  ///

namespace Test1
{

    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
    }

    public class BookingMessage
    {
     public BookingMessage(DateTime pickupDate)
     {
        if (pickupDate < DateTime.Now)
        {
            throw new ArgumentException(); 
        }

        PickupDate = pickupDate;

     }
        public System.DateTime PickupDate {get; private set; }
    }
     
    [TestClass]
    public class when_create_booking_for_reservation_system
    {
        [TestInitialize]
        public void Initialized()
        {
            SystemTime.Now = () => new DateTime (2012, 1, 1);
        }


        [TestMethod]
        public void it_must_include_a_pickup_date()
        {
            //Arrange
            DateTime pickupDate =  new DateTime(2012, 1, 1);

            //Act
            var booking = new BookingMessage(pickupDate);

            //Asset
            Assert.AreEqual(pickupDate, booking.PickupDate);
        }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void it_fails_if_pickup_date_is_in_the_past()
    {
        DateTime pickupDate = new DateTime(2012, 12, 31);

        var booking = new BookingMessage(pickupDate);

        Assert.Fail("Message Constructor should have thrown an exception");


        }
    }
}
