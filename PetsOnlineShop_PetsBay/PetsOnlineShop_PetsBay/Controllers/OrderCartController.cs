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
    public class OrderCartController : Controller
    {
        private PetsBayEntities db = new PetsBayEntities();

        // GET: OrderCart
        public ActionResult Index()
        {
            var order_Cart = db.Order_Cart.Include(o => o.Category_Details).Include(o => o.Customer_Details).Include(o => o.Pet_Details);
            return View(order_Cart.ToList());
        }

        // GET: OrderCart/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Cart order_Cart = db.Order_Cart.Find(id);
            if (order_Cart == null)
            {
                return HttpNotFound();
            }
            return View(order_Cart);
        }

        // GET: OrderCart/Create
        public ActionResult Create()
        {
            ViewBag.Category_Id = new SelectList(db.Category_Details, "Id", "Pet_Breed");
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name");
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category");
            return View();
        }

        // POST: OrderCart/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Customer_Id,Pets_Id,Category_Id,Order_Quantity,Order_Price,Order_Date,Order_ShippingDate,Order_Flag,Order_Status")] Order_Cart order_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Order_Cart.Add(order_Cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_Id = new SelectList(db.Category_Details, "Id", "Pet_Breed", order_Cart.Category_Id);
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", order_Cart.Customer_Id);
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", order_Cart.Pets_Id);
            return View(order_Cart);
        }

        // GET: OrderCart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Cart order_Cart = db.Order_Cart.Find(id);
            if (order_Cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_Id = new SelectList(db.Category_Details, "Id", "Pet_Breed", order_Cart.Category_Id);
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", order_Cart.Customer_Id);
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", order_Cart.Pets_Id);
            return View(order_Cart);
        }

        // POST: OrderCart/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Customer_Id,Pets_Id,Category_Id,Order_Quantity,Order_Price,Order_Date,Order_ShippingDate,Order_Flag,Order_Status")] Order_Cart order_Cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order_Cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_Id = new SelectList(db.Category_Details, "Id", "Pet_Breed", order_Cart.Category_Id);
            ViewBag.Customer_Id = new SelectList(db.Customer_Details, "Id", "Customer_Name", order_Cart.Customer_Id);
            ViewBag.Pets_Id = new SelectList(db.Pet_Details, "Id", "Pet_Category", order_Cart.Pets_Id);
            return View(order_Cart);
        }

        // GET: OrderCart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order_Cart order_Cart = db.Order_Cart.Find(id);
            if (order_Cart == null)
            {
                return HttpNotFound();
            }
            return View(order_Cart);
        }

        // POST: OrderCart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order_Cart order_Cart = db.Order_Cart.Find(id);
            db.Order_Cart.Remove(order_Cart);
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
