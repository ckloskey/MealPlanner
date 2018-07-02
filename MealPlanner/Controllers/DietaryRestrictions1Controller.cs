using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MealPlanner.Models;

namespace MealPlanner.Controllers
{
    public class DietaryRestrictions1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: DietaryRestrictions1
        public ActionResult Index()
        {
            return View(db.DietaryRestriction.ToList());
        }

        // GET: DietaryRestrictions1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietaryRestriction dietaryRestriction = db.DietaryRestriction.Find(id);
            if (dietaryRestriction == null)
            {
                return HttpNotFound();
            }
            return View(dietaryRestriction);
        }

        // GET: DietaryRestrictions1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DietaryRestrictions1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Restriction")] DietaryRestriction dietaryRestriction)
        {
            if (ModelState.IsValid)
            {
                db.DietaryRestriction.Add(dietaryRestriction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dietaryRestriction);
        }

        // GET: DietaryRestrictions1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietaryRestriction dietaryRestriction = db.DietaryRestriction.Find(id);
            if (dietaryRestriction == null)
            {
                return HttpNotFound();
            }
            return View(dietaryRestriction);
        }

        // POST: DietaryRestrictions1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Restriction,IsAllergic")] DietaryRestriction dietaryRestriction)
        {
            if (ModelState.IsValid)
            {
                DietaryRestriction dietaryRestriction1 = db.DietaryRestriction.Find(dietaryRestriction.Id);
                dietaryRestriction1.IsAllergic = dietaryRestriction.IsAllergic;
                dietaryRestriction.Restriction = dietaryRestriction1.Restriction;
                db.Entry(dietaryRestriction1).State = EntityState.Modified;
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dietaryRestriction);
        }

        // GET: DietaryRestrictions1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DietaryRestriction dietaryRestriction = db.DietaryRestriction.Find(id);
            if (dietaryRestriction == null)
            {
                return HttpNotFound();
            }
            return View(dietaryRestriction);
        }

        // POST: DietaryRestrictions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DietaryRestriction dietaryRestriction = db.DietaryRestriction.Find(id);
            db.DietaryRestriction.Remove(dietaryRestriction);
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
