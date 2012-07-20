using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CavanGaelsCarRentals.Models.ui;

namespace CavanGaelsCarRentals.Logic
{
    interface IServiceLayer
    {
        LocationsUI ListAvailableLocations();
         
        LocationCarsCount TotalCarsAvailable(string location);

        BookingUI ListAvailableCars(LocationsUI requestedTimePlace);

        BookingCreateUI ShowChosenCar(BookingUI selectedCar);

        BookingConfirmUI ShowBookingConfirm(BookingCreateUI booking);

    }
}
