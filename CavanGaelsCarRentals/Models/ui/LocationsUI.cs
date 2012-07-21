using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CavanGaelsCarRentals.Models.ui
{
    public class LocationsUI
    {
         public string location { get; set; }
        public SelectList locations { get; set; }
        public DateTime fromDate { get; set; }

        public DateTime toDate { get; set; }

    }
}