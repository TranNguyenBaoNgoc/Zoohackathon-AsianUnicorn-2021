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
    public class AnimalProductsController : Controller
    {
        private Hackathon2021Entities db = new Hackathon2021Entities();

        // GET: AnimalProducts
        public async Task<ActionResult> Index()
        {
            var animalProducts = db.AnimalProducts.Include(a => a.Animal);
            return View(await animalProducts.ToListAsync());
        }

        // GET: AnimalProducts/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalProduct animalProduct = await db.AnimalProducts.FindAsync(id);
            if (animalProduct == null)
            {
                return HttpNotFound();
            }
            return View(animalProduct);
        }

        // GET: AnimalProducts/Create
        public ActionResult Create()
        {
            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "CommonName");
            return View();
        }

        // POST: AnimalProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "AnimalProductsID,AnimalProductsName,DescriptionAnimalProducts,AnimalID")] AnimalProduct animalProduct)
        {
            if (ModelState.IsValid)
            {
                db.AnimalProducts.Add(animalProduct);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "CommonName", animalProduct.AnimalID);
            return View(animalProduct);
        }

        // GET: AnimalProducts/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalProduct animalProduct = await db.AnimalProducts.FindAsync(id);
            if (animalProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "CommonName", animalProduct.AnimalID);
            return View(animalProduct);
        }

        // POST: AnimalProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "AnimalProductsID,AnimalProductsName,DescriptionAnimalProducts,AnimalID")] AnimalProduct animalProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalProduct).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalID = new SelectList(db.Animals, "AnimalID", "CommonName", animalProduct.AnimalID);
            return View(animalProduct);
        }

        // GET: AnimalProducts/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalProduct animalProduct = await db.AnimalProducts.FindAsync(id);
            if (animalProduct == null)
            {
                return HttpNotFound();
            }
            return View(animalProduct);
        }

        // POST: AnimalProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AnimalProduct animalProduct = await db.AnimalProducts.FindAsync(id);
            db.AnimalProducts.Remove(animalProduct);
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
