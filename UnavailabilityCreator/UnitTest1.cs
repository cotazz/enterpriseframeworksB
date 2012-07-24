using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

     ///     When creating a unavailability for the system
    ///  - must include a start date
    ///  - start date must be in the future
    ///  - must include a end date
    ///  - end must be later than start date


    public class UnavailabilityCreator
    {
        private DateTime _startdate;
        public UnavailabilityCreator (DateTime start_date, DateTime end_date)
        {
            _startdate = start_date;
        }

       public DateTime StartDate
        {
            get
            {
                return this._startdate;
            }
            set
            {
                this._startdate = value;
            }
           
    }
    }

    [TestClass]
    public class When_create_UnavailabilityCreator
    {
        [TestMethod]
        public void it_must_includ_a_start_date()
        {
	
        // Arrange
               DateTime start_date = new DateTime(2012, 10, 1);
               DateTime end_date = new DateTime(2012, 11, 1);
               // Act
               var unavailability_message = new UnavailabilityCreator(start_date, end_date);

               // Assert
               Assert.AreEqual(unavailability_message.StartDate, start_date);
        
    
        //         [TestMethod]
        //  [ExpectedException(typeof(ArgumentException))]
        //  public void start_date_must_be_in_future()
        //          {
        //       // Arrange
        //       DateTime start_date = new DateTime(2012, 1, 1);
        //       DateTime end_date = new DateTime(2012, 1, 1);
        //       // Act
        //       var unavailability_message = new UnavailabilityCreator(start_date, end_date);

        //       // Assert
        //       Assert.Fail("Message Constructor should have thrown an exception");

        //     }

        //  [TestMethod]
        //  public void it_must_include_an_end_date()
        //  {
        //       // Arrange
        //       DateTime start_date = new DateTime(2012, 10, 1);
        //       DateTime end_date = new DateTime(2012, 11, 1);

        //       // Act
        //       var unavailability_message = new UnavailabilityCreator(start_date, end_date);

        //       // Assert
        //       Assert.AreEqual(unavailability_message.EndDate,  end_date);
        //  }


        //  [TestMethod]
        //  [ExpectedException(typeof(ArgumentException))]
        //  public void end_date_must_be_later_than_start_date()
        //  {
        //       // Arrange
        //       DateTime start_date = new DateTime(2012, 10, 1);
        //       DateTime end_date = new DateTime(2012, 7, 1);

        //       // Act
        //       var unavailability_message = new UnavailabilityCreator(start_date, end_date);

        //       // Assert
        //       Assert.Fail("Message Constructor should have thrown an exception");
          //
        }
     }
    

