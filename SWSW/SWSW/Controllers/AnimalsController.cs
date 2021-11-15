using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWSW.Model;

namespace SWSW.Controllers
{
    public class AnimalsController : Controller
    {
        private Hackathon2021Entities1 db = new Hackathon2021Entities1();

        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.ConservationStatu).Include(a => a.Class).Include(a => a.ProtectionStatu);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup");
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass");
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionDescription");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalID,CommonName,ScientificName,EnglishName,DistributionAnimal,IDClass,ProtectionID,ConservationID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup", animal.ConservationID);
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass", animal.IDClass);
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionDescription", animal.ProtectionID);
            return View(animal);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup", animal.ConservationID);
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass", animal.IDClass);
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionDescription", animal.ProtectionID);
            return View(animal);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalID,CommonName,ScientificName,EnglishName,DistributionAnimal,IDClass,ProtectionID,ConservationID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup", animal.ConservationID);
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass", animal.IDClass);
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionDescription", animal.ProtectionID);
            return View(animal);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = db.Animals.Find(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animal animal = db.Animals.Find(id);
            db.Animals.Remove(animal);
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
