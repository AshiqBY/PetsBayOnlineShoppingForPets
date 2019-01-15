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
    public class CustomerController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Customer
        public ActionResult Index()
        {
            return View(db.Customer_Details.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Customer_Name,Customer_Gender,Customer_DateOfBirth,Customer_MobileNumber,Customer_EmailId,Customer_BillingAddress,Customer_City,Cusromer_State,Customer_Pincode,Customer_UserName,Customer_Password,Customer_ImagePath,Customer_ImageName,Customer_ActivationDate")] Customer_Details customer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Details.Add(customer_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_Details);
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Customer_Name,Customer_Gender,Customer_DateOfBirth,Customer_MobileNumber,Customer_EmailId,Customer_BillingAddress,Customer_City,Cusromer_State,Customer_Pincode,Customer_UserName,Customer_Password,Customer_ImagePath,Customer_ImageName,Customer_ActivationDate")] Customer_Details customer_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_Details);
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            if (customer_Details == null)
            {
                return HttpNotFound();
            }
            return View(customer_Details);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Details customer_Details = db.Customer_Details.Find(id);
            db.Customer_Details.Remove(customer_Details);
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
