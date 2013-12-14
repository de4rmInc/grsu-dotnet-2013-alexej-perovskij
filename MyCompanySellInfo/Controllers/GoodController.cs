﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyCompanySellInfo.Models;

namespace MyCompanySellInfo.Controllers
{
    public class GoodController : Controller
    {
        private ProductionEntities db = new ProductionEntities();

        // GET: /Good/
        [Authorize(Roles = "canEdit,canDelete")]
        public ActionResult Index()
        {
            return View(db.Goods.ToList());
        }

        // GET: /Good/Details/5
        [Authorize(Roles = "canEdit,canDelete")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // GET: /Good/Create
        [Authorize(Roles = "canEdit,canDelete")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Good/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit,canDelete")]
        public ActionResult Create([Bind(Include="Id,Name,Producer,Cost")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Goods.Add(good);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(good);
        }

        // GET: /Good/Edit/5
        [Authorize(Roles = "canEdit,canDelete")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // POST: /Good/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "canEdit,canDelete")]
        public ActionResult Edit([Bind(Include="Id,Name,Producer,Cost")] Good good)
        {
            if (ModelState.IsValid)
            {
                db.Entry(good).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(good);
        }

        // GET: /Good/Delete/5
        [Authorize(Roles = "canDelete")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Good good = db.Goods.Find(id);
            if (good == null)
            {
                return HttpNotFound();
            }
            return View(good);
        }

        // POST: /Good/Delete/5
        [Authorize(Roles = "canDelete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Good good = db.Goods.Find(id);
            db.Goods.Remove(good);
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
