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
    public class OrderController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: Order
        public ActionResult Index()
        {
            var order_Details = db.Order_Details.Include(o => o.Customer_Details).Include(o => o.Pet_Details);
            return View(order_Details.ToList());
        }

        // GET: Order/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name");
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Customer_Id,Pet_Id,Order_Details_ShippingAddress,Order_Details_ShippingCity,Order_Details_ShippingState,Order_Details_ShippingPincode,Order_Details_DeliveryDate,Order_Details_ModeOfPayment,Order_Details_TotalPrice,Order_Details_Flag")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Order_Details.Add(order_Details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", order_Details.Customer_Id);
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", order_Details.Pet_Id);
            return View(order_Details);
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", order_Details.Customer_Id);
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", order_Details.Pet_Id);
            return View(order_Details);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Customer_Id,Pet_Id,Order_Details_ShippingAddress,Order_Details_ShippingCity,Order_Details_ShippingState,Order_Details_ShippingPincode,Order_Details_DeliveryDate,Order_Details_ModeOfPayment,Order_Details_TotalPrice,Order_Details_Flag")] Order_Details order_Details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", order_Details.Customer_Id);
            ViewBag.Pet_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", order_Details.Pet_Id);
            return View(order_Details);
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Details order_Details = db.Order_Details.Find(id);
            if (order_Details == null)
            {
                return HttpNotFound();
            }
            return View(order_Details);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Details order_Details = db.Order_Details.Find(id);
            db.Order_Details.Remove(order_Details);
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
