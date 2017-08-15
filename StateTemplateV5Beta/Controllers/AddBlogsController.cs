using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StateTemplateV5Beta;
using StateTemplateV5Beta.Models;

namespace StateTemplateV5Beta.Controllers
{
    public class AddBlogsController : Controller
    {
        private CSLDataModel db = new CSLDataModel();

        public ActionResult Admin()
        {
            return View();
        }

        // GET: AddBlogs
        public ActionResult Blogs()
        {
            return View(db.AddBlogs);
        }


        // GET: AddBlogs
        public ActionResult Index()
        {
            return View(db.AddBlogs.ToList());
        }

        // GET: AddBlogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddBlog addBlog = db.AddBlogs.Find(id);
            if (addBlog == null)
            {
                return HttpNotFound();
            }
            return View(addBlog);
        }

        // GET: AddBlogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddBlogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Description")] AddBlog addBlog)
        {
            if (ModelState.IsValid)
            {
                db.AddBlogs.Add(addBlog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addBlog);
        }

        // GET: AddBlogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddBlog addBlog = db.AddBlogs.Find(id);
            if (addBlog == null)
            {
                return HttpNotFound();
            }
            return View(addBlog);
        }

        // POST: AddBlogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlogID,Title,Description")] AddBlog addBlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addBlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addBlog);
        }

        // GET: AddBlogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddBlog addBlog = db.AddBlogs.Find(id);
            if (addBlog == null)
            {
                return HttpNotFound();
            }
            return View(addBlog);
        }

        // POST: AddBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddBlog addBlog = db.AddBlogs.Find(id);
            db.AddBlogs.Remove(addBlog);
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
