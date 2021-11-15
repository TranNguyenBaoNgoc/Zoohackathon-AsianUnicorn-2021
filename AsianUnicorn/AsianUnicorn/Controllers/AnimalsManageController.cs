using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AsianUnicorn.Models;

namespace AsianUnicorn.Controllers
{
    public class AnimalsManageController : Controller
    {
        private Hackathon2021Entities db = new Hackathon2021Entities();

        // GET: AnimalsManage
        public async Task<ActionResult> Index()
        {
            var animals = db.Animals.Include(a => a.ConservationStatu).Include(a => a.Class).Include(a => a.ProtectionStatu);
            return View(await animals.ToListAsync());
        }

        // GET: AnimalsManage/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // GET: AnimalsManage/Create
        public ActionResult Create()
        {
            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup");
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass");
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionGroup");
            return View();
        }

        // POST: AnimalsManage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AnimalID,CommonName,ScientificName,EnglishName,DistributionAnimal,IDClass,ProtectionID,ConservationID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Animals.Add(animal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup", animal.ConservationID);
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass", animal.IDClass);
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionGroup", animal.ProtectionID);
            return View(animal);
        }

        // GET: AnimalsManage/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup", animal.ConservationID);
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass", animal.IDClass);
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionGroup", animal.ProtectionID);
            return View(animal);
        }

        // POST: AnimalsManage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AnimalID,CommonName,ScientificName,EnglishName,DistributionAnimal,IDClass,ProtectionID,ConservationID")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ConservationID = new SelectList(db.ConservationStatus, "ConservationID", "ConservationGroup", animal.ConservationID);
            ViewBag.IDClass = new SelectList(db.Classes, "IDClass", "NameClass", animal.IDClass);
            ViewBag.ProtectionID = new SelectList(db.ProtectionStatus, "ProtectionID", "ProtectionGroup", animal.ProtectionID);
            return View(animal);
        }

        // GET: AnimalsManage/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animal animal = await db.Animals.FindAsync(id);
            if (animal == null)
            {
                return HttpNotFound();
            }
            return View(animal);
        }

        // POST: AnimalsManage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Animal animal = await db.Animals.FindAsync(id);
            db.Animals.Remove(animal);
            await db.SaveChangesAsync();
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
