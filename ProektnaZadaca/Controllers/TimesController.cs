using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProektnaZadaca.Models;

namespace ProektnaZadaca.Controllers
{
    [Authorize]
    public class TimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Times
        public ActionResult Index()
        {
            var time = db.Time.Include(t => t.Flight);
            return View(time.ToList());
        }

        [HttpPost]
        public ActionResult SearchResults(string fromLocation, string dest, DateTime departureDate)
        {
            ViewBag.fromLocation = fromLocation;
            ViewBag.dest = dest;
            ViewBag.ScheduleMessage = "";
            if (DateTime.Compare(departureDate, DateTime.Today) > 0)
            {
                var data = from s in db.Time
                           where s.fromLocation == fromLocation && s.dest == dest
                           && s.departureDate == departureDate  
                           select s;
                if (data.ToList().Count() == 0)
                {
                    ViewBag.ScheduleMessage = "No flights were found with those parameters";
                    data = from s in db.Time
                           where s.fromLocation == fromLocation && s.dest == dest
                           && DateTime.Compare(s.departureDate, DateTime.Today) > 0
                           select s;
                }
                return View(data.ToList());
            }
            else
            {
                var data = from s in db.Time
                           where s.fromLocation == fromLocation && s.dest == dest
                           && DateTime.Compare(s.departureDate, DateTime.Today) >= 0
                           select s;
                ViewBag.ScheduleMessage = "You can't filter from a date in the past.";
                return View(data.ToList());
            }

        }

        // GET: Times/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Time.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // GET: Times/Create
        [Authorize(Users = "administrator@test.com")]
        public ActionResult Create()
        {
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName");
            return View();
        }

        // POST: Times/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "administrator@test.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "timeId,flightId,fromLocation,dest,departureDate,depatureTime")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Time.Add(time);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName", time.flightId);
            return View(time);
        }

        // GET: Times/Edit/5
        [Authorize(Users = "administrator@test.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Time.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName", time.flightId);
            return View(time);
        }

        // POST: Times/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Users = "administrator@test.com")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "timeId,flightId,fromLocation,dest,departureDate,depatureTime")] Time time)
        {
            if (ModelState.IsValid)
            {
                db.Entry(time).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName", time.flightId);
            return View(time);
        }

        // GET: Times/Delete/5
        [Authorize(Users = "administrator@test.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Time time = db.Time.Find(id);
            if (time == null)
            {
                return HttpNotFound();
            }
            return View(time);
        }

        // POST: Times/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "administrator@test.com")]
        public ActionResult DeleteConfirmed(int id)
        {
            Time time = db.Time.Find(id);
            db.Time.Remove(time);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
