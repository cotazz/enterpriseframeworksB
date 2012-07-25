using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models;
using System.IO;
using CavanGaelsCarRentals.Ingestion;
using CavanGaelsCarRentals.DataAccess;

namespace CavanGaelsCarRentals.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }


        // how to upload file: http://haacked.com/archive/2010/07/16/uploading-files-with-aspnetmvc.aspx
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {

             // how to parse a csv using LumenWorks CSV parser, Ref Arian Skehill, Lecturer NCI
             IDataparser csv = new CSVParser();
             StreamReader reader = new StreamReader(file.InputStream);
             csv.setStreamSource(reader);
             List<Car> results = csv.parseCars();
             var dal = new Db();
             var cars = dal.Cars.ToList();
             List<string> car_ids = new List<string>();
             foreach (var c in cars)
                  car_ids.Add(c.car_reg);
             foreach (var c in results)
             {
                  if (car_ids.Contains(c.car_reg))
                       continue;
                  c.SupplierId = 1;
                  dal.Cars.Add(c);
             }
             dal.SaveChanges();
             return RedirectToAction("Index");
        }


        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
