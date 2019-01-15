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
    public class Feedback_DetailsController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Feedback_Details
        public ActionResult Index()
        {
            var feedback_Details = db.Feedback_Details.Include(f => f.Customer_Details).Include(f => f.Seller_Details);
            return View(feedback_Details.ToList());
        }

        // GET: Feedback_Details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback_Details feedback_Details = db.Feedback_Details.Find(id);
            if (feedback_Details == null)
            {
                return HttpNotFound();
            }
            return View(feedback_Details);
        }

        // GET: Feedback_Details/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name");
            ViewBag.Pet_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name");
            return View();
        }

        // POST: Feedback_Details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Customer_Id,Pet_Id,Feedback_Message,Feedback_Rating,Feedback_Date")] Feedback_Details feedback_Details)
        {
            if (ModelState.IsValid)
            {
                db.Feedback_Details.Add(feedback_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", feedback_Details.Customer_Id);
            ViewBag.Pet_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name", feedback_Details.Pet_Id);
            return View(feedback_Details);
        }

        // GET: Feedback_Details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback_Details feedback_Details = db.Feedback_Details.Find(id);
            if (feedback_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", feedback_Details.Customer_Id);
            ViewBag.Pet_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name", feedback_Details.Pet_Id);
            return View(feedback_Details);
        }

        // POST: Feedback_Details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Customer_Id,Pet_Id,Feedback_Message,Feedback_Rating,Feedback_Date")] Feedback_Details feedback_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedback_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", feedback_Details.Customer_Id);
            ViewBag.Pet_Id = new SelectList(db.Seller_Details, "Id", "Seller_Name", feedback_Details.Pet_Id);
            return View(feedback_Details);
        }

        // GET: Feedback_Details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedback_Details feedback_Details = db.Feedback_Details.Find(id);
            if (feedback_Details == null)
            {
                return HttpNotFound();
            }
            return View(feedback_Details);
        }

        // POST: Feedback_Details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedback_Details feedback_Details = db.Feedback_Details.Find(id);
            db.Feedback_Details.Remove(feedback_Details);
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
