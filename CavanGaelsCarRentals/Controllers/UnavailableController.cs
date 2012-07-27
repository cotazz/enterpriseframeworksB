using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CavanGaelsCarRentals.Models;
using CavanGaelsCarRentals.DataAccess;

namespace CavanGaelsCarRentals.Controllers
{
    public class UnavailableController : Controller
    {
        private Db db = new Db();

        //
        // GET: /Unavailable/

        public ActionResult Index()
        {
            var unavailabilities = db.Unavailabilities.Include(u => u.Car);
            return View(unavailabilities.ToList());
        }

        //
        // GET: /Unavailable/Details/5

        public ActionResult Details(int id = 0)
        {
            Unavailable unavailable = db.Unavailabilities.Find(id);
            if (unavailable == null)
            {
                return HttpNotFound();
            }
            return View(unavailable);
        }

        //
        // GET: /Unavailable/Create

        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars, "Id", "car_reg");
            return View();
        }

        //
        // POST: /Unavailable/Create

        [HttpPost]
        public ActionResult Create(Unavailable unavailable)
        {
            if (ModelState.IsValid)
            {
                db.Unavailabilities.Add(unavailable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "Id", "car_reg", unavailable.CarId);
            return View(unavailable);
        }

        //
        // GET: /Unavailable/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Unavailable unavailable = db.Unavailabilities.Find(id);
            if (unavailable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "car_reg", unavailable.CarId);
            return View(unavailable);
        }

        //
        // POST: /Unavailable/Edit/5

        [HttpPost]
        public ActionResult Edit(Unavailable unavailable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unavailable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "car_reg", unavailable.CarId);
            return View(unavailable);
        }

        //
        // GET: /Unavailable/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Unavailable unavailable = db.Unavailabilities.Find(id);
            if (unavailable == null)
            {
                return HttpNotFound();
            }
            return View(unavailable);
        }

        //
        // POST: /Unavailable/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Unavailable unavailable = db.Unavailabilities.Find(id);
            db.Unavailabilities.Remove(unavailable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}