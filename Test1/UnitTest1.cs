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
  /// - Booking should calculate total cost (daily rate, number of days)
  ///

namespace Test1
{

    public static class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.Now;
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
            DateTime pickupDate =  new DateTime(2013, 1, 1);

            //Act

            var booking = BookingBObj.newBooking(new CarBObj(new SupplierBObj()));
            booking.setBookingRange(pickupDate, 10);

            //Asset
            Assert.AreEqual(pickupDate, booking.startDate());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void it_fails_if_pickup_date_is_in_the_past()
        {
            DateTime pickupDate = new DateTime(2011, 12, 31);

            var booking = BookingBObj.newBooking(new CarBObj(new SupplierBObj()));
            booking.setBookingRange(pickupDate, 10);

            Assert.Fail("Message Constructor should have thrown an exception");


        }
    

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void booking_end_date_Should_be_after_start_date()
        {
            DateTime pickupDate = new DateTime(2012, 12, 31);

            var booking = BookingBObj.newBooking(new CarBObj(new SupplierBObj()));
            booking.setBookingRange(pickupDate, -5);

            Assert.Fail("Message Constructor should have thrown an exception");


         }
        

         [TestMethod]
        public void Booking_should_have_car_id_and_customer_id()
        {
            int car_id = 5;
            int customer_id = 1;

            var car = new CarBObj(new SupplierBObj());
            car.setId(car_id);

            var customer = new CustomerBObj();
            customer.setId(customer_id);

            var booking = BookingBObj.newBooking( car );
            booking.setCustomer(customer);
             

            Assert.AreEqual(car_id, booking.getCar().getId() );
            Assert.AreEqual(customer_id, booking.getCustomer().getId() );



        }

         [TestMethod]
         public void  Booking_should_calculate_total_cost()
        {
            DateTime pickupDate = new DateTime(2012, 12, 31);

            var car = new CarBObj(new SupplierBObj());
            car.setDailyRate(50);

            var booking = BookingBObj.newBooking(car);
            booking.setBookingRange(pickupDate, 10);

            Assert.AreEqual(car.dailyRate() * 10, booking.getTotalCost());

        }
    }
}

