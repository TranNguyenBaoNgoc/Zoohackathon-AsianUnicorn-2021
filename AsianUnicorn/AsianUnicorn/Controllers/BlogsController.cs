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
    public class BlogsController : Controller
    {
        private Hackathon2021Entities db = new Hackathon2021Entities();

        // GET: Blogs
        public async Task<ActionResult> Index()
        {
            var blogs = db.Blogs.Include(b => b.Category_Blog).Include(b => b.Blog_Tag);
            return View(await blogs.ToListAsync());
        }

        // GET: Blogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.Category_BlogID = new SelectList(db.Category_Blog, "Catagory_BlogID", "Name");
            ViewBag.TagID = new SelectList(db.Blog_Tag, "Blog_TagID", "Blog_TagID");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "BlogID,Name,Description,StartDate,Author,Category_BlogID,TagID")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Category_BlogID = new SelectList(db.Category_Blog, "Catagory_BlogID", "Name", blog.Category_BlogID);
            ViewBag.TagID = new SelectList(db.Blog_Tag, "Blog_TagID", "Blog_TagID", blog.TagID);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_BlogID = new SelectList(db.Category_Blog, "Catagory_BlogID", "Name", blog.Category_BlogID);
            ViewBag.TagID = new SelectList(db.Blog_Tag, "Blog_TagID", "Blog_TagID", blog.TagID);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "BlogID,Name,Description,StartDate,Author,Category_BlogID,TagID")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Category_BlogID = new SelectList(db.Category_Blog, "Catagory_BlogID", "Name", blog.Category_BlogID);
            ViewBag.TagID = new SelectList(db.Blog_Tag, "Blog_TagID", "Blog_TagID", blog.TagID);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await db.Blogs.FindAsync(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Blog blog = await db.Blogs.FindAsync(id);
            db.Blogs.Remove(blog);
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
