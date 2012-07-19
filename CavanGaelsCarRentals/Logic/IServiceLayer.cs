using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CavanGaelsCarRentals.Models.ui;

namespace CavanGaelsCarRentals.Logic
{
    interface IServiceLayer
    {
        public LocationsUI ListAvailableLocations();
         
        public LocationCarsCount TotalCarsAvailable(string location);

        public BookingUI ListAvailableCars(LocationsUI requestedTimePlace);

        public BookingCreateUI ShowChosenCar(BookingUI selectedCar);

        public BookingConfirmUI ShowBookingConfirm(BookingCreateUI booking);

    }
}
