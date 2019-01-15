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
    public class PetsController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Pets
        public ActionResult Index()
        {
            var pet_Details = db.Pet_Details.Include(p => p.Seller_Details);
            return View(pet_Details.ToList());
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            if (pet_Details == null)
            {
                return HttpNotFound();
            }
            return View(pet_Details);
        }

        // GET: Pets/Create
        public ActionResult Create()
        {
            ViewBag.Seller_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name");
            return View();
        }

        // POST: Pets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Seller_Id,Pet_Category,Pet_Description,Pet_Color,Pet_Age,Pet_Weight,Pet_Gender,Pet_AvailableQuantity,Pet_Price,Pet_ImagePath,Pet_ImageName,Flag")] Pet_Details pet_Details)
        {
            if (ModelState.IsValid)
            {
                db.Pet_Details.Add(pet_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Seller_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name", pet_Details.Seller_Id);
            return View(pet_Details);
        }

        // GET: Pets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            if (pet_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Seller_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name", pet_Details.Seller_Id);
            return View(pet_Details);
        }

        // POST: Pets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Seller_Id,Pet_Category,Pet_Description,Pet_Color,Pet_Age,Pet_Weight,Pet_Gender,Pet_AvailableQuantity,Pet_Price,Pet_ImagePath,Pet_ImageName,Flag")] Pet_Details pet_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Seller_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name", pet_Details.Seller_Id);
            return View(pet_Details);
        }

        // GET: Pets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            if (pet_Details == null)
            {
                return HttpNotFound();
            }
            return View(pet_Details);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet_Details pet_Details = db.Pet_Details.Find(id);
            db.Pet_Details.Remove(pet_Details);
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
