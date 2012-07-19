using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CavanGaelsCarRentals.Logic
{
    public class ServiveLayer : IServiceLayer
    {
        public Models.ui.LocationsUI ListAvailableLocations()
        {
            throw new NotImplementedException();
        }

        public Models.ui.LocationCarsCount TotalCarsAvailable(string location)
        {
            throw new NotImplementedException();
        }

        public Models.ui.BookingUI ListAvailableCars(Models.ui.LocationsUI requestedTimePlace)
        {
            throw new NotImplementedException();
        }

        public Models.ui.BookingCreateUI ShowChosenCar(Models.ui.BookingUI selectedCar)
        {
            throw new NotImplementedException();
        }

        public Models.ui.BookingConfirmUI ShowBookingConfirm(Models.ui.BookingCreateUI booking)
        {
            throw new NotImplementedException();
        }
    }
}