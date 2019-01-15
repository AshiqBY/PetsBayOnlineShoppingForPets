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
    public class AccessoriesController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Accessories
        public ActionResult Index()
        {
            var accessories_Details = db.Accessories_Details.Include(a => a.Pet_Details);
            return View(accessories_Details.ToList());
        }

        // GET: Accessories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories_Details accessories_Details = db.Accessories_Details.Find(id);
            if (accessories_Details == null)
            {
                return HttpNotFound();
            }
            return View(accessories_Details);
        }

        // GET: Accessories/Create
        public ActionResult Create()
        {
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category");
            return View();
        }

        // POST: Accessories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Pets_Id,Accessories_Name,Accessories_Quantity,Accessories_Price,Accessories_Description,Accessories_ImagePath,Accessories_ImageName")] Accessories_Details accessories_Details)
        {
            if (ModelState.IsValid)
            {
                db.Accessories_Details.Add(accessories_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", accessories_Details.Pets_Id);
            return View(accessories_Details);
        }

        // GET: Accessories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories_Details accessories_Details = db.Accessories_Details.Find(id);
            if (accessories_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", accessories_Details.Pets_Id);
            return View(accessories_Details);
        }

        // POST: Accessories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Pets_Id,Accessories_Name,Accessories_Quantity,Accessories_Price,Accessories_Description,Accessories_ImagePath,Accessories_ImageName")] Accessories_Details accessories_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessories_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", accessories_Details.Pets_Id);
            return View(accessories_Details);
        }

        // GET: Accessories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accessories_Details accessories_Details = db.Accessories_Details.Find(id);
            if (accessories_Details == null)
            {
                return HttpNotFound();
            }
            return View(accessories_Details);
        }

        // POST: Accessories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accessories_Details accessories_Details = db.Accessories_Details.Find(id);
            db.Accessories_Details.Remove(accessories_Details);
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
