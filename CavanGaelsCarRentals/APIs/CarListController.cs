using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models.ui;
using CavanGaelsCarRentals.Logic;
using CavanGaelsCarRentals.DataAccess;
using CavanGaelsCarRentals.Models;

namespace CavanGaelsCarRentals.APIs
{
    public class CarListController : ApiController
    {
        Repository db = new Repository(); 
        
        //
        // Get /api/carList
         public IEnumerable<Car> Get(string location)
        {
             
             var carList = db.listAvailableCars(location,DateTime.Now.AddDays(10),DateTime.Now.AddDays(20));
             return carList;

        }
        
        
        
    }
}