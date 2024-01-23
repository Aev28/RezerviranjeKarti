using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProektnaZadaca.Models;

namespace ProektnaZadaca.Controllers
{
    [Authorize]
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var ticket = db.Ticket.Include(t => t.Flight).Include(t => t.Time);
            return View(ticket.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName");
            ViewBag.scheduleId = new SelectList(db.Time, "timeId", "fromLocation");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticketId,flightId,scheduleId,destination,dateOfJourney,nameAndSurname,phoneNumber,address,isReturn,package")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Ticket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index", "Times");
            }
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName", ticket.flightId);
            ViewBag.scheduleId = new SelectList(db.Time, "timeId", "fromLocation", ticket.scheduleId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [Authorize(Users = "administrator@test.com")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName", ticket.flightId);
            ViewBag.scheduleId = new SelectList(db.Time, "timeId", "fromLocation", ticket.scheduleId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "administrator@test.com")]
        public ActionResult Edit([Bind(Include = "ticketId,flightId,scheduleId,destination,dateOfJourney,nameAndSurname,phoneNumber,address,isReturn,package")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.flightId = new SelectList(db.Flight, "flightId", "flightName", ticket.flightId);
            ViewBag.scheduleId = new SelectList(db.Time, "timeId", "fromLocation", ticket.scheduleId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize(Users = "administrator@test.com")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Ticket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "administrator@test.com")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Ticket.Find(id);
            db.Ticket.Remove(ticket);
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
