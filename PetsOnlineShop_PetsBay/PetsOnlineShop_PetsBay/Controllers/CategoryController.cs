using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetsOnlineShop_PetsBay;

namespace PetsOnlineShop_PetsBay.Controllers
{
    public class CategoryController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Category
        public ActionResult Index()
        {
            var category_Details = db.Category_Details.Include(c => c.Pet_Details);
            return View(category_Details.ToList());
        }

        // GET: Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Details category_Details = db.Category_Details.Find(id);
            if (category_Details == null)
            {
                return HttpNotFound();
            }
            return View(category_Details);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pet_Id,Pet_Breed")] Category_Details category_Details)
        {
            if (ModelState.IsValid)
            {
                db.Category_Details.Add(category_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", category_Details.Pet_Id);
            return View(category_Details);
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Details category_Details = db.Category_Details.Find(id);
            if (category_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", category_Details.Pet_Id);
            return View(category_Details);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pet_Id,Pet_Breed")] Category_Details category_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", category_Details.Pet_Id);
            return View(category_Details);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category_Details category_Details = db.Category_Details.Find(id);
            if (category_Details == null)
            {
                return HttpNotFound();
            }
            return View(category_Details);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category_Details category_Details = db.Category_Details.Find(id);
            db.Category_Details.Remove(category_Details);
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
