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
    public class SellerController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Seller
        public ActionResult Index()
        {
            return View(db.Seller_Details.ToList());
        }

        // GET: Seller/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller_Details seller_Details = db.Seller_Details.Find(id);
            if (seller_Details == null)
            {
                return HttpNotFound();
            }
            return View(seller_Details);
        }

        // GET: Seller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Seller/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Seller_Name,Seller_Address,Seller_City,Seller_State,Seller_Pincode,Seller_EmailId,Seller_MobileNo,Seller_UserId,Seller_ImagePath,Seller_ImageName,Seller_Password")] Seller_Details seller_Details)
        {
            if (ModelState.IsValid)
            {
                db.Seller_Details.Add(seller_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(seller_Details);
        }

        // GET: Seller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller_Details seller_Details = db.Seller_Details.Find(id);
            if (seller_Details == null)
            {
                return HttpNotFound();
            }
            return View(seller_Details);
        }

        // POST: Seller/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Seller_Name,Seller_Address,Seller_City,Seller_State,Seller_Pincode,Seller_EmailId,Seller_MobileNo,Seller_UserId,Seller_ImagePath,Seller_ImageName,Seller_Password")] Seller_Details seller_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(seller_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(seller_Details);
        }

        // GET: Seller/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Seller_Details seller_Details = db.Seller_Details.Find(id);
            if (seller_Details == null)
            {
                return HttpNotFound();
            }
            return View(seller_Details);
        }

        // POST: Seller/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Seller_Details seller_Details = db.Seller_Details.Find(id);
            db.Seller_Details.Remove(seller_Details);
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
