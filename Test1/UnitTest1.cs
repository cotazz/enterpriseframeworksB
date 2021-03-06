﻿using System;
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

         /// <summary>
         /// This test ensures pickup date can not be in the past
         /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void it_fails_if_pickup_date_is_in_the_past()
        {

             // 1. Arrange
            DateTime pickupDate = new DateTime(2011, 12, 31);
            var booking = BookingBObj.newBooking(new CarBObj(new SupplierBObj()));

             // 2. Act
            booking.setBookingRange(pickupDate, 10);

             // 3. Assert - if the test gets this far, there is a problem!
            Assert.Fail("Message Constructor should have thrown an exception");


        }
    
         /// <summary>
         /// The pickup date must be before the return date
         /// </summary>
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
            car.setDailyRate(30);

            var booking = BookingBObj.newBooking(car);
            booking.setBookingRange(pickupDate, 10);

            Assert.AreEqual(car.dailyRate() * 10, booking.getTotalCost());
            Assert.AreEqual(300, booking.getTotalCost());
        }

         [TestMethod]
         public void Booking_should_not_be_valid_if_car_unavailable_before_and_during_period()
         {
              DateTime pickupDate = new DateTime(2012, 12, 31);
              DateTime alreadyTakenDateBefore = new DateTime(2012,11,10);
              DateTime alreadyTakenDateAfter = new DateTime(2013, 02, 10);
              DateTime alreadyTakenDateDuring = new DateTime(2013, 01, 04);

              var car = new CarBObj(new SupplierBObj());
              car.setDailyRate(50);

              var booking = BookingBObj.newBooking(car);
              booking.setBookingRange(pickupDate, 10);

              var customer = new CustomerBObj();
              customer.setId(1);

              booking.setCustomer(customer);
              car.setId(1);

              var takenDates = new List<UnavailableDateBObj>();

              var unavailability = new UnavailableDateBObj { fromDate = alreadyTakenDateBefore, toDate = alreadyTakenDateDuring };
              takenDates.Add(unavailability);

              Assert.IsFalse(booking.valid(takenDates));
         }

         [TestMethod]
         public void Booking_should_be_valid_if_no_car_unavailabilities_exist()
         {
              DateTime pickupDate = new DateTime(2012, 12, 31);
              var car = new CarBObj(new SupplierBObj());
              car.setDailyRate(50);

              var booking = BookingBObj.newBooking(car);
              booking.setBookingRange(pickupDate, 10);

              var customer = new CustomerBObj();
              customer.setId(1);

              booking.setCustomer(customer);
              car.setId(1);

              var takenDates = new List<UnavailableDateBObj>();
              Assert.IsTrue(booking.valid(takenDates));

         }

         [TestMethod]
         public void Booking_should_create_and_return_an_UnavailableDateBObj()
         {
              DateTime pickupDate = new DateTime(2012, 12, 31);
              var car = new CarBObj(new SupplierBObj());
              car.setDailyRate(50);

              var booking = BookingBObj.newBooking(car);
              booking.setBookingRange(pickupDate, 10);

              var unavailable = new UnavailableDateBObj { fromDate = pickupDate, toDate = pickupDate.AddDays(10) };
              var customer = new CustomerBObj();
              customer.setId(1);

              booking.setCustomer(customer);
              car.setId(1);

              var takenDates = new List<UnavailableDateBObj>();

              
              Assert.AreEqual(booking.create().ToString() , unavailable.ToString() );

         }

    }
}

