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
    public class Category_BlogController : Controller
    {
        private Hackathon2021Entities db = new Hackathon2021Entities();

        // GET: Category_Blog
        public async Task<ActionResult> Index()
        {
            return View(await db.Category_Blog.ToListAsync());
        }

        // GET: Category_Blog/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Blog category_Blog = await db.Category_Blog.FindAsync(id);
            if (category_Blog == null)
            {
                return HttpNotFound();
            }
            return View(category_Blog);
        }

        // GET: Category_Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category_Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Catagory_BlogID,Name,Description")] Category_Blog category_Blog)
        {
            if (ModelState.IsValid)
            {
                db.Category_Blog.Add(category_Blog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(category_Blog);
        }

        // GET: Category_Blog/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Blog category_Blog = await db.Category_Blog.FindAsync(id);
            if (category_Blog == null)
            {
                return HttpNotFound();
            }
            return View(category_Blog);
        }

        // POST: Category_Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Catagory_BlogID,Name,Description")] Category_Blog category_Blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_Blog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(category_Blog);
        }

        // GET: Category_Blog/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Blog category_Blog = await db.Category_Blog.FindAsync(id);
            if (category_Blog == null)
            {
                return HttpNotFound();
            }
            return View(category_Blog);
        }

        // POST: Category_Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Category_Blog category_Blog = await db.Category_Blog.FindAsync(id);
            db.Category_Blog.Remove(category_Blog);
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
