﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CavanGaelsCarRentals.Models.ui;

namespace CavanGaelsCarRentals.Logic
{
    interface IServiceLayer
    {
        LocationsUI ListAvailableLocations();
         
        LocationCarsCount TotalCarsAvailable(string location, string fromDate, string toDate);

        BookingUI ListAvailableCars(LocationsUI requestedTimePlace);

        BookingCreateUI ShowChosenCar(BookingCreateUI selectedCar);

        BookingConfirmUI CreateBooking(BookingCreateUI booking, int userId);

        BookingConfirmUI ShowBookingConfirm(int booking_id, int userId);

    }
}
