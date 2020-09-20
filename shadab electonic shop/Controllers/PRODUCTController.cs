using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shadab_electonic_shop.Models;

namespace shadab_electonic_shop.Controllers
{
    public class PRODUCTController : Controller
    {
        private ELECTRIC_SHOPEntities db = new ELECTRIC_SHOPEntities();

        // GET: PRODUCT
        public ActionResult Index()
        {
            var pRODUCTs = db.PRODUCTs.Include(p => p.BRAND).Include(p => p.CATEGORY);
            return View(pRODUCTs.ToList());
        }

        // GET: PRODUCT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: PRODUCT/Create
        public ActionResult Create()
        {
            ViewBag.BRAND_ID = new SelectList(db.BRANDs, "ID", "BRAND1");
            ViewBag.CAT_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY1");
            return View();
        }

        // POST: PRODUCT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PRODUCTNAME,CAT_ID,BRAND_ID,QUANTITY,PRICE")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTs.Add(pRODUCT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BRAND_ID = new SelectList(db.BRANDs, "ID", "BRAND1", pRODUCT.BRAND_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY1", pRODUCT.CAT_ID);
            return View(pRODUCT);
        }

        // GET: PRODUCT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            ViewBag.BRAND_ID = new SelectList(db.BRANDs, "ID", "BRAND1", pRODUCT.BRAND_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY1", pRODUCT.CAT_ID);
            return View(pRODUCT);
        }

        // POST: PRODUCT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PRODUCTNAME,CAT_ID,BRAND_ID,QUANTITY,PRICE")] PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BRAND_ID = new SelectList(db.BRANDs, "ID", "BRAND1", pRODUCT.BRAND_ID);
            ViewBag.CAT_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY1", pRODUCT.CAT_ID);
            return View(pRODUCT);
        }

        // GET: PRODUCT/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // POST: PRODUCT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUCT pRODUCT = db.PRODUCTs.Find(id);
            db.PRODUCTs.Remove(pRODUCT);
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
